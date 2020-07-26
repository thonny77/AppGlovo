using AppGlovo.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppGlovo.Transfers
{
    public class Usuariodt
    {
        [Key]
        public int id_us { get; set; }

        [RegularExpression("\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*")]
        public string usuario { get; set; }
        public string password { get; set; }
        public Nullable<int> estado { get; set; }
        public string token { get; set; }
        public virtual ICollection<personas> personas { get; set; }
    }
}