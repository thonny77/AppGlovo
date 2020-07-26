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
    public class UsuarioController : ApiController
    {
        // GET: api/Usuario
        public IEnumerable<usuariospersonas> Get(int id)
        {
            return usuarios.ListarUsuarios(id);
        }

        
        public bool Post([FromBody] usuarios usu)
        {
            return usuarios.InsertarUsuario(usu);
        }
    }
}
