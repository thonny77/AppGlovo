using AppGlovo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppGlovo.Transfers
{
    public class pedidosDTO
    {

        public int id_pedido { get; set; }
        public Nullable<System.DateTime> fecha_pedido { get; set; }
        public Nullable<int> puntuacion { get; set; }
        public Nullable<int> estado { get; set; }
        public Nullable<System.DateTime> fecha_entrega { get; set; }
        public Nullable<decimal> costo_envio { get; set; }
        public string propina { get; set; }
        public int personas_id_per { get; set; }
        public int personas_id_per1 { get; set; }
        public int sedes_id_sedes { get; set; }
        public string comprobante { get; set; }
        public Nullable<int> pagado { get; set; }
        public string destino { get; set; }
        public string origen { get; set; }
        public string firma { get; set; }


        public virtual ICollection<comisiones> comisiones { get; set; }
        
        public virtual ICollection<detalle_pedidos> detalle_pedidos { get; set; }
        public virtual establecimientos establecimientos { get; set; }
        

        public virtual ICollection<eventos> eventos { get; set; }
        public virtual personas personas { get; set; }
        public virtual personas personas1 { get; set; }

    }
}