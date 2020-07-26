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
    public class EmpresasController : ApiController
    {
        // GET : api/Empresas
        public IEnumerable<empresasdt> Get()
        {
            return empresas.ListadoEmpresas();
        }

        // GET: api/Empresas/5
        public IEnumerable<empresasdt> Get(int id)
        {
            return empresas.BuscarCategoria(id);
        }

        // POST: api/Empresas
        public bool Post([FromBody] empresas emp)
        {
            return empresas.RegistrarEmpresa(emp);
        }

        // PUT: api/Empresas/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Empresas/5
        [HttpDelete]
        public bool Delete(int id)
        {
            return empresas.BorrarEmpresa(id);
        }
    }
}
