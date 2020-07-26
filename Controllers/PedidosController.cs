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
    public class PedidosController : ApiController
    {
        // GET: api/Pedidos/usu=asuario
        public IEnumerable<pedidosDTO> Get(int usu)
        {
            return pedidos.ListarPedido(usu);
        }

        // GET: api/Pedidos
        public IEnumerable<pedidosDTO> Get()
        {
            return pedidos.ListarAll();
        }

        // POST: api/Pedidos
        public bool Post([FromBody]pedidos p)
        {
            return pedidos.Insert(p);
        }

        // PUT: api/Pedidos/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Pedidos/5
        public bool Delete(int id)
        {
            return pedidos.Delete(id);
        }
    }
}
