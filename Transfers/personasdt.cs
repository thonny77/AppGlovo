using AppGlovo.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppGlovo.Transfers
{
    public class personasdt
    {
        [Key]
        public int id_per { get; set; }
        public string nombres { get; set; }
        public string correo { get; set; }
        public string direccion { get; set; }
        [RegularExpression("[0-9]{9}")]
        public string telefono { get; set; }
        [RegularExpression("[0-9]{8}")]
        public string documento { get; set; }
        public string tipo_vehiculo { get; set; }
        public Nullable<int> tipo_persona { get; set; }
        [RegularExpression("[a-zA-Z]+(.jpeg|.JPEG|.gif|.GIF| .png|.PNG|.jpg)")]
        public string foto { get; set; }
        public virtual ICollection<tarjetas> tarjetas { get; set; }
    }
}