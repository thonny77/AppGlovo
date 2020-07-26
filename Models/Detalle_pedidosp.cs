using AppGlovo.Transfers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppGlovo.Models
{
    public partial class detalle_pedidos
    {
        public static IEnumerable<DetallePedidoDTO> ListarDetallePedido(int id)
        {
            dbglovoEntities1 db = new dbglovoEntities1();

            var det = from dp in db.detalle_pedidos.Where(x => x.pedido_id_pedido == id)
                      select new DetallePedidoDTO
                      {
                          id_detalle = dp.id_detalle,
                          cantidad = dp.cantidad,
                          precio = dp.precio,
                          nombre_producto = dp.nombre_producto,
                          total = dp.total,
                          pedido_id_pedido = dp.pedido_id_pedido,
                          producto_sku = dp.producto_sku
                          
                      };

            return det;

        }

    }
}