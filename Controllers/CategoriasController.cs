using AppGlovo.Models;
using AppGlovo.Transfers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AppGlovo.Controllers
{
    public class CategoriasController : ApiController
    {
        // GET: api/Categorias
        public IEnumerable<categoriasDTO> Get(string tipo)
        {
            return categorias.CategoryByTipo(tipo);
        }

        // GET: api/Categorias/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Categorias
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Categorias/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Categorias/5
        public void Delete(int id)
        {
        }
    }
}
