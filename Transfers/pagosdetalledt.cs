using AppGlovo.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace AppGlovo.Transfers
{
    public class pagosdetalledt
    {
        [Key]
        public int id_detalle { get; set; }
        public Nullable<decimal> tarifa_base { get; set; }
        public Nullable<decimal> propina { get; set; }
        public Nullable<decimal> extras { get; set; }
        public Nullable<decimal> costo_recorrido { get; set; }
        public Nullable<decimal> descuento { get; set; }
        public Nullable<decimal> total { get; set; }
        public int cod_fact { get; set; }
        public int id_comisiones { get; set; }

        public virtual comisiones comisiones { get; set; }
        public virtual pagos pagos { get; set; }
    }
}