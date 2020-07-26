using AppGlovo.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace AppGlovo.Transfers
{
    public class pagosdt
    {        
        [Key]
        public int codigo_factura { get; set; }
        public string moneda { get; set; }
        public Nullable<decimal> igv { get; set; }
        [Display(Name ="Numero de RUC")]
        public string ruc { get; set; }
        [Display(Name ="Monto tatal del pago")]
        public Nullable<decimal> monto_total { get; set; }
        [DisplayFormat(DataFormatString = "{yyyy-MM-ddTHH:mm:ss}", ApplyFormatInEditMode = true)]
        //[DateType (DateType.Date)]
        public Nullable<System.DateTime> fecha_pago { get; set; }
        public Nullable<decimal> descuento { get; set; }
        public Nullable<System.DateTime> fecha_inicio { get; set; }
        public Nullable<System.DateTime> fecha_fin { get; set; }

        public int id_persona { get; set; }
        public virtual personas personas { get; set; }        
        public virtual IEnumerable<detalle_pago> detalle_pago { get; set; }

    }
}