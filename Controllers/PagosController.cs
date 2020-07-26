using AppGlovo.Models;
using AppGlovo.Transfers;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace AppGlovo.Controllers
{
    public class   PagosController : ApiController
    {
        // GET: api/Pagos
        [Authorize]
        [HttpGet]
        public IEnumerable<pagosdt> Get()
        {
            return Pagos.Listpagos();
        }

        public int Get(DateTime x, DateTime y, int us)
        {
            return Pagos.GeneratePayGlover(x,y,us);
        }

        [HttpGet]
        // GET: api/Pagos/5
        public IEnumerable<pagosdt> Get(int id)
        {
            return Pagos.ListById(id);
        }

        // POST: api/Pagos
        [HttpPost]
        public bool  Post([FromBody] pagos pago)
        {
            return Pagos.InsertPagos(pago);
        }

        // PUT: api/Pagos/5
        [HttpPut]
        public bool Put(int id, [FromBody] pagos pago)
        {
            return Pagos.UpdatePagos(pago,id);
        }

        // DELETE: api/Pagos/5
        [HttpDelete]
        public bool Delete(int id)
        {
            return Pagos.Delete(id);
        }
    }
}
