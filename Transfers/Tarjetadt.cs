using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppGlovo.Transfers
{
    public class Tarjetadt
    {
        [Key]
        public int id_tarjeta { get; set; }
        public int personas_id_per { get; set; }
        public string numero_cuenta { get; set; }
        public string numero_tarjeta { get; set; }

    }
}