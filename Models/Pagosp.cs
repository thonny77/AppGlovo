using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppGlovo.Transfers;
using AppGlovo.Models;
using Microsoft.Ajax.Utilities;
using System.Web.Http.Results;
using System.Data.Entity;
using Microsoft.SqlServer.Server;
using System.Diagnostics;

namespace AppGlovo.Models
{
   
    
    public partial class Pagos
    {        
        public static IEnumerable<pagosdt> Listpagos()
        
        {
            dbglovoEntities1 db = new dbglovoEntities1();

            var list = from b in db.pagos.Where(x => x.id_persona > 0).ToList()
                       select new pagosdt()
                       {                           
                           codigo_factura=b.codigo_factura,
                           moneda= b.moneda,
                           igv= b.igv,
                           ruc= b.ruc,
                           monto_total= b.monto_total,
                           fecha_pago= b.fecha_pago,
                           descuento= b.descuento,
                           fecha_inicio= b.fecha_inicio,
                           fecha_fin= b.fecha_fin,
                           id_persona= b.id_persona
                       };

            return list;
        }

        public static IEnumerable<pagosdt> ListById(int id)
        {
            dbglovoEntities1 db = new dbglovoEntities1();
            

            var list = from b in db.pagos.Where(x => x.codigo_factura == id).Include(f => f.detalle_pago).ToList()
                       select new pagosdt()
                       {
                           codigo_factura = b.codigo_factura,
                           moneda = b.moneda,
                           igv = b.igv,
                           ruc = b.ruc,
                           monto_total = b.monto_total,
                           fecha_pago = b.fecha_pago,
                           descuento = b.descuento,
                           fecha_inicio = b.fecha_inicio,
                           fecha_fin = b.fecha_fin,
                           id_persona = b.id_persona
                           //detalle_pago = b.detalle_pago

                           
                       };
           
                return list;
           
        }
        public static  bool InsertPagos(pagos pago)
        {
            dbglovoEntities1 db = new dbglovoEntities1();

            pago.igv = pago.monto_total * (decimal)0.18;

            try
            {
                
                pago.fecha_pago = DateTime.Today;
                //pago.detalle_pago = null;
                var detalle = pago.detalle_pago;
                pago.detalle_pago = null;

                db.pagos.Add(pago);
                
                db.SaveChanges();


                int ids = pago.codigo_factura;
                //int ids = db.pagos.Last().codigo_factura;
                //pago.detalle_pago = detalle;

                

                foreach (var dp  in detalle)
                {
                    detalle_pago dt = new detalle_pago();
                    dt.cod_fact = ids;
                    dt.id_comisiones = dp.id_comisiones;

                    dt.tarifa_base = (decimal)1.5;

                    if (dp.propina == null){dt.propina = (decimal) 0.0;}
                    else { dt.propina = dp.propina; }
                    
                    if (dp.extras == null) {dt.extras = (decimal)0.0;}
                    else { dt.extras = dp.extras*(decimal)0.1;}
                    
                    dt.costo_recorrido = dp.costo_recorrido*(decimal)0.6;

                    if (dp.descuento == null){ dt.descuento = (decimal)0.0; }
                    else { dt.descuento = (decimal)dp.descuento; }                    

                    dt.total = (dt.tarifa_base + dt.propina + dt.extras + dt.costo_recorrido) - dt.descuento;
                    

                    db.detalle_pago.Add(dt);                  

                }

                db.SaveChanges();



                return true;
            }
            catch(Exception e) {

                Console.WriteLine(e.Message);

                return false;
            }
        }

        public static int  GeneratePayGlover(DateTime l, DateTime t, int us) 
        {
            dbglovoEntities1 db = new dbglovoEntities1();

            try 
            {
                //lista de comisiones por rango de fecha de un glover
                var com = from c in db.comisiones
                                join p in db.pedidos on c.id_pedidos equals p.id_pedido
                                where(p.personas_id_per1 == us)
                                where(p.fecha_pedido >= l && p.fecha_pedido <= t && c.estado ==1)
                                select new ComisionesDTO 
                                {
                                    id =c.id,
                                    kilometraje=c.kilometraje,
                                    tiempo_espera=c.tiempo_espera,
                                    id_pedidos=c.id_pedidos,
                                    extras=c.extras,
                                    estado=c.estado , 
                                    descuento=c.descuento,
                                    propina=c.propina
                                };


                if (com.Count() > 0) { 
                
                    // mostrar tarifa  del glover
                    var tf = db.tarifas.Where(b=> b.id_glover == us).FirstOrDefault();
                    //mostar datos del glover
                    var ifog = db.personas.Where(b=>b.id_per==us).FirstOrDefault();

                    decimal mt = 0;
                    decimal igv = 0;
                    decimal descuento = 0;

                    foreach (ComisionesDTO ls in com)
                    {
                        mt = mt + (tf.precio_base + (decimal)(tf.precio_km*ls.kilometraje)+ (decimal)(tf.precio_espera*ls.tiempo_espera) + (decimal)(ls.extras*tf.precio_km) +(decimal)ls.propina);
                        descuento = descuento + (decimal)ls.descuento;
                    }
                
                
                    igv = mt * (decimal)0.18;

                    pagos pg = new pagos();
                    pg.moneda = "1";
                    pg.igv = igv;
                    pg.ruc = ifog.documento;
                    pg.monto_total = mt;
                    pg.fecha_pago = DateTime.Today;
                    pg.descuento = descuento;
                    pg.fecha_inicio = l;
                    pg.fecha_fin = t;
                    pg.id_persona = us;

                    db.pagos.Add(pg);
                    db.SaveChanges();

                    int idfac = pg.codigo_factura;

                    foreach (ComisionesDTO cm in com)
                    {
                        detalle_pago pd = new detalle_pago();

                        pd.id_comisiones = cm.id;
                        pd.cod_fact = idfac;
                        pd.tarifa_base = tf.precio_base;
                        pd.propina = cm.propina;
                        pd.extras = cm.extras * tf.precio_km;
                        pd.costo_recorrido = cm.kilometraje * tf.precio_km;
                        pd.descuento = cm.descuento;
                        pd.total = pd.tarifa_base + pd.propina + pd.extras + pd.costo_recorrido - pd.descuento;

                        db.detalle_pago.Add(pd);
                    }
                    db.SaveChanges();
                    return idfac;
                }
                return 0;                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return 0;
            }
        
    }

        public static bool UpdatePagos(pagos pago, int id)
        {
            dbglovoEntities1 db = new dbglovoEntities1();
            pago.igv = pago.monto_total * (decimal)0.18;
            try
            {
                //db.pagos.Find(id);
                db.Entry(pago).State = EntityState.Modified;
                db.SaveChanges();
                
                return true;
            }
            catch
            {
                /*Console.WriteLine("el id es:"+id + " Codigo es:"+pago.codigo_factura);
                Console.WriteLine(e.Message);*/
                return false;
            }
        }
        public static bool Delete(int id)
        {
            dbglovoEntities1 db = new dbglovoEntities1();

            try {
                var ids = db.pagos.Find(id);
                db.pagos.Remove(ids);
                db.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}