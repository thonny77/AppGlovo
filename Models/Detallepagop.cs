using AppGlovo.Transfers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace AppGlovo.Models
{
    public class Detallepagop
    {
        public static IEnumerable<pagosdetalledt> ListDetallepagos()

        {
            dbglovoEntities1 db = new dbglovoEntities1();

            var list = from b in db.detalle_pago.Where(x => x.id_detalle > 0).ToList()
                select new pagosdetalledt()
                {
                    id_detalle = b.id_detalle,
                    tarifa_base =b.tarifa_base,
                    propina =b.propina,
                    extras =b.extras,
                    costo_recorrido =b.costo_recorrido,
                    descuento =b.descuento,
                    total =b.total,
                    cod_fact =b.cod_fact,
                    id_comisiones =b.id_comisiones,
                };

            return list;
        }

        public static bool InsertDetalle(detalle_pago dp)
        {
            dbglovoEntities1 db = new dbglovoEntities1();

            try
            {
                
                detalle_pago dt = new detalle_pago();
                dt.tarifa_base = (decimal)1.5;

                if (dp.propina == null) { dt.propina = 0; }
                else { dt.propina = dp.propina; }

                if (dp.extras == null) { dt.extras = 0; }
                else { dt.extras = dp.extras * (decimal)0.1; }

                dt.costo_recorrido = dp.costo_recorrido * (decimal)1.4;

                if (dt.descuento == null) { dt.descuento = 0; }
                else { dt.descuento = dp.descuento; }

                dt.total = (dt.tarifa_base + dt.propina + dt.extras + dt.costo_recorrido) - dt.descuento;
                dt.id_comisiones = dp.id_comisiones;

                db.detalle_pago.Add(dt);
                db.SaveChanges();

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public static IEnumerable<pagosdetalledt> DetallePagoById(int id) {


            dbglovoEntities1 db = new dbglovoEntities1();


            var detalles = from m in db.detalle_pago.Where(t => t.cod_fact == id)
                           select new pagosdetalledt {

                               id_detalle= m.id_detalle,
                               tarifa_base= m.tarifa_base,
                               propina=m.propina,
                               extras=m.extras,
                               costo_recorrido=m.costo_recorrido,
                               descuento=m.descuento,
                               total=m.total,
                                cod_fact=m.cod_fact
                           };
                               

                return detalles;


            
                
        }

    }
}