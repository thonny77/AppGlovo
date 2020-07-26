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
    public class HorarioController : ApiController
    {
        // GET: api/Horario
        public IEnumerable<HorarioGlover2> Get(int id)
        {
            return Horario_glover.ListarHorario(id);
        }

        // POST: api/Horario
        public bool Post([FromBody] Horario_glover hor)
        {
            return Horario_glover.AgregarHorario(hor);
        }

        // PUT: api/Horario/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Horario/5
        public bool Delete(int id)
        {
            return Horario_glover.EliminarHorario(id);
        }

    }
}
