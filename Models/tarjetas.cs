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
    
    public partial class tarjetas
    {
        public int id_tarjeta { get; set; }
        public int personas_id_per { get; set; }
        public string numero_cuenta { get; set; }
        public string numero_tarjeta { get; set; }
    
        public virtual personas personas { get; set; }
    }
}
