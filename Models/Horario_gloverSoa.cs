using AppGlovo.Transfers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;


namespace AppGlovo.Models
{
    public  partial class Horario_glover
    {

        public static IEnumerable<HorarioGlover2> ListarHorario(int id)
        {
            dbglovoEntities1 db = new dbglovoEntities1();

            var list = from p in db.personas
                       join b in db.Horario_glover on p.id_per equals b.id_glover
                       join c in db.horario on b.id_horario equals c.id
                       /*select p.id_us, p.usuario, p.password, c.nombres, c.documento, c.tipo_vehiculo, t.numero_cuenta, h.dia, h.id_horario*/
                       where (p.id_per.Equals(id))
                       select new HorarioGlover2()
                       {
                           idhg = b.idhg,
                           dia = b.dia,
                           id_glover= b.id_glover
                       };
            return list;
        }
        public static bool AgregarHorario([FromBody] Horario_glover hor)
        {
            dbglovoEntities1 db = new dbglovoEntities1();

            db.Horario_glover.Add(hor);
            db.SaveChanges();

            return true;

        }
        public static bool EliminarHorario(int id)
        {
            dbglovoEntities1 db = new dbglovoEntities1();

            try
            {
                db.Horario_glover.Remove(db.Horario_glover.Find(id));
                db.SaveChanges();
                return true;
            }
            catch
            {

                return false;
            }
        }

    }
}