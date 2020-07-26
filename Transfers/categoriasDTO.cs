using AppGlovo.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppGlovo.Transfers
{
    public class categoriasDTO
    {

        [Key]
        public int id { get; set; }
        public string nombre_categoria { get; set; }
        public string descripcion { get; set; }
        public string tipo { get; set; }

        
        public virtual ICollection<empresas> empresas { get; set; }
       
        public virtual ICollection<productos> productos { get; set; }
    }
}