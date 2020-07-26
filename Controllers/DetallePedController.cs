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
    public class DetallePedController : ApiController
    {
        // GET: api/DetallePed
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/DetallePed/5
        public IEnumerable<DetallePedidoDTO> Get(int id)
        {
            return detalle_pedidos.ListarDetallePedido(id);
        }

        // POST: api/DetallePed
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/DetallePed/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/DetallePed/5
        public void Delete(int id)
        {
        }
    }
}
