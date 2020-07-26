using AppGlovo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AppGlovo.Controllers
{
    // Controller cliente
    public class CrearUsuarioController : ApiController
    {

        // GET: api/CrearUsuario
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/CrearUsuario/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/CrearUsuario
        public bool CrearUsuario([FromBody] usuarios usu)
        {
            return usuarios.CrearUsuario(usu);
        }

        // PUT: api/CrearUsuario/5
        [HttpPut]
        public bool Actualizar(int id, [FromBody] usuarios usu)
        {
            return usuarios.Actualizar(id, usu);
        }

        // DELETE: api/CrearUsuario/5
        public bool Delete(int id)
        {
            return usuarios.EliminarUsuario(id);
        }
    }
}
