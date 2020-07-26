using AppGlovo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppGlovo.Transfers
{
    public class empresasdt
    {
        public int id_empresa { get; set; }
        public string nombres { get; set; }
        public string documento { get; set; }
        public string cbu { get; set; }
        public string pais { get; set; }
        public int categoria_id { get; set; }
        public int usuario_id_us { get; set; }
        public string correo_empresa { get; set; }

        public virtual categorias categorias { get; set; }
        
        public virtual ICollection<establecimientos> establecimientos { get; set; }


    }
}