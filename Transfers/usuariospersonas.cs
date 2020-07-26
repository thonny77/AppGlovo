using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppGlovo.Transfers
{
    public class usuariospersonas
    {
        public int id_us { get; set; }

        public string usuario { get; set; }
        public string password { get; set; }
        public string nombres { get; set; }
        public string documento { get; set; }
        public string tipo_vehiculo { get; set; }
        public string numero_cuenta { get; set; }
    }
}