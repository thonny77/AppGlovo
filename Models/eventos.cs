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
    
    public partial class eventos
    {
        public int id { get; set; }
        public string estado { get; set; }
        public string descripcion { get; set; }
        public Nullable<System.DateTime> hora { get; set; }
        public int pedido_id_pedido { get; set; }
    
        public virtual pedidos pedidos { get; set; }
    }
}