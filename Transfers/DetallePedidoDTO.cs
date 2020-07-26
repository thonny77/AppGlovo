using AppGlovo.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppGlovo.Transfers
{
    public class DetallePedidoDTO
    {

        [Key]
        public int id_detalle { get; set; }
        public Nullable<int> cantidad { get; set; }
        public Nullable<decimal> precio { get; set; }
        public string nombre_producto { get; set; }
        public Nullable<decimal> total { get; set; }
        public int pedido_id_pedido { get; set; }
        public int producto_sku { get; set; }

        public virtual productos productos { get; set; }
        public virtual pedidos pedidos { get; set; }
    }
}