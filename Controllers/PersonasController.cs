using AppGlovo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AppGlovo.Controllers
{
    public class PersonasController : ApiController
    {
        // GET: api/Personas
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Personas/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Personas
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Personas/5
        public bool Put(int id, [FromBody] personas per)
        {
            return personas.ModificarGLover(id, per);
        }

        // DELETE: api/Personas/5
        public bool Delete(int id)
        {
            return personas.EliminarGlover(id);
        }
    }
}
