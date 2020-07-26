using AppGlovo.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppGlovo.Transfers
{
    public class productosdt
    {
        [Key]
        public int sku { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public Nullable<decimal> precio { get; set; }
        
        public string foto { get; set; }
        public int categoria_id { get; set; }
        public Nullable<int> stock { get; set; }
        public Nullable<decimal> precio_promo { get; set; }
        public Nullable<System.DateTime> fv_promo { get; set; }
        public string codigo_producto { get; set; }

        public virtual categorias categorias { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<detalle_pedidos> detalle_pedidos { get; set; }
    }
}