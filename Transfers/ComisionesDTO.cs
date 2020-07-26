using AppGlovo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppGlovo.Transfers
{
    public class ComisionesDTO
    {
        public int id { get; set; }
        public Nullable<System.DateTime> fecha { get; set; }
        public Nullable<decimal> kilometraje { get; set; }
        public Nullable<int> tiempo_espera { get; set; }
        public int id_pedidos { get; set; }
        public Nullable<decimal> extras { get; set; }
        public int estado { get; set; }
        public Nullable<decimal> propina { get; set; }
        public Nullable<decimal> descuento { get; set; }
        public virtual pedidos pedidos { get; set; }
        
        public virtual ICollection<detalle_pago> detalle_pago { get; set; }
    }
}