//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AppGlovo.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class comisiones
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public comisiones()
        {
            this.detalle_pago = new HashSet<detalle_pago>();
        }
    
        public int id { get; set; }
        public Nullable<decimal> kilometraje { get; set; }
        public Nullable<int> tiempo_espera { get; set; }
        public int id_pedidos { get; set; }
        public Nullable<decimal> extras { get; set; }
        public int estado { get; set; }
        public Nullable<decimal> propina { get; set; }
        public Nullable<decimal> descuento { get; set; }
    
        public virtual pedidos pedidos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<detalle_pago> detalle_pago { get; set; }
    }
}
