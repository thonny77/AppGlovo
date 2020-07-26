using AppGlovo.Transfers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Permissions;
using System.Web;

namespace AppGlovo.Models
{
    public  partial  class pedidos
    {

        public static IEnumerable<pedidosDTO> ListarAll()
        {
            dbglovoEntities1 db = new dbglovoEntities1();

            var list = from p in db.pedidos.Where(p => p.estado>0).ToList()
                       select new pedidosDTO()
                       {
                            id_pedido = p.id_pedido,
                            fecha_pedido = p.fecha_pedido,
                            puntuacion = p.puntuacion,
                            estado = p.estado,
                            fecha_entrega = p.fecha_entrega,
                            costo_envio = p.costo_envio,
                            personas_id_per = p.personas_id_per,
                            personas_id_per1 = p.personas_id_per1,
                            sedes_id_sedes = p.sedes_id_sedes,
                            comprobante = p.comprobante,
                            pagado = p.pagado,
                            destino = p.destino,
                            origen = p.origen,
                            firma = p.firma
        };

            return list;
        }

        public static IEnumerable<pedidosDTO> ListarPedido(int ped) 
        {
            dbglovoEntities1 db = new dbglovoEntities1();

            var list = from p in db.pedidos.Where(p=>p.personas_id_per == ped).ToList()
                 select new pedidosDTO()
                 {
                     id_pedido = p.id_pedido,
                     fecha_pedido = p.fecha_pedido,
                     puntuacion = p.puntuacion,
                     estado = p.estado,
                     fecha_entrega = p.fecha_entrega,
                     costo_envio = p.costo_envio,
                     personas_id_per = p.personas_id_per,
                     personas_id_per1 = p.personas_id_per1,
                     sedes_id_sedes = p.sedes_id_sedes,
                     comprobante = p.comprobante,
                     pagado = p.pagado,
                     destino = p.destino,
                     origen = p.origen,
                     firma = p.firma
                 };

            return list;
        }


        public static bool  Insert(pedidos p)
        {
            dbglovoEntities1 db = new dbglovoEntities1();

            try 
            {
                var cli = db.personas.Find(p.personas_id_per);
                Decimal total=0;var d=p.detalle_pedidos;

                foreach (detalle_pedidos dp in d) 
                {
                    var pr = db.productos.Find(dp.producto_sku);
                    total = total+ ((decimal)pr.precio * (decimal)dp.cantidad);
                    dp.precio = pr.precio;
                    dp.total=pr.precio * (decimal)dp.cantidad;
                    dp.nombre_producto = pr.nombre;
                }
                
                p.fecha_pedido= DateTime.Now;
                p.estado = 1;
                p.costo_envio = total;
                if (p.pagado > 0)
                {
                    string comp = "c-" + cli.documento + p.fecha_pedido + ".jpg";
                    p.comprobante = comp.Trim(new Char[] { ' ', '/', ':' });
                    p.firma = ("f-" + cli.documento + p.fecha_pedido + ".jpg").Trim(new Char[] { ' ', '/', ':' });
                }
                else
                {
                    p.comprobante = "0";
                    p.firma = "0";
                }

                db.pedidos.Add(p);
                db.SaveChanges();

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return false;
            }
            
        }


        public static bool Delete(int id)
        {
            dbglovoEntities1 db = new dbglovoEntities1();
            try
            {
                var idp = db.pedidos.Find(id);
                var idpd = db.detalle_pedidos.Where(b => b.pedido_id_pedido == id).Count();
                if (idpd > 0)
                { 
                    db.detalle_pedidos.RemoveRange(db.detalle_pedidos.Where(c=>c.pedido_id_pedido == id));
                    db.SaveChanges();
                }
                db.pedidos.Remove(idp);
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