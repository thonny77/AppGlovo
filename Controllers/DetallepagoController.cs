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
    public class DetallepagoController : ApiController
    {
        // GET: api/Detallepago
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Detallepago/5
        [Authorize]
        public IEnumerable<pagosdetalledt> Get(int id)
        {
            return Detallepagop.DetallePagoById(id);
        }

        // POST: api/Detallepago
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Detallepago/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Detallepago/5
        public void Delete(int id)
        {
        }
    }
}
