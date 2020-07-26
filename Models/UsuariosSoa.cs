using AppGlovo.Transfers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace AppGlovo.Models
{
    public partial class usuarios
    {
        public static IEnumerable<usuariospersonas> ListarUsuarios(int id)
        {
            dbglovoEntities1 db = new dbglovoEntities1();

            var list = from b in db.usuarios
                       join c in db.personas on b.id_us equals c.usuario_id_us
                       join e in db.tarjetas on c.id_per equals e.personas_id_per
                       /*select p.id_us, p.usuario, p.password, c.nombres, c.documento, c.tipo_vehiculo, t.numero_cuenta, h.dia, h.id_horario*/
                       where (c.id_per.Equals(id))
                       select new usuariospersonas()

                       {
                           id_us = b.id_us,
                           usuario = b.usuario,
                           password = b.password,
                           nombres = c.nombres,
                           documento = c.documento,
                           tipo_vehiculo = c.tipo_vehiculo,
                           numero_cuenta = e.numero_cuenta,
                        };

            return list;
        }

        public static bool InsertarUsuario(usuarios usu)
        {
            dbglovoEntities1 db = new dbglovoEntities1();
            try
            {
                var persona = usu.personas;
                var tarjeta = db.tarjetas;
                var correo = usu.usuario;
                var hola = db.usuarios.Where(x => x.usuario == correo).Count();
                if (hola == 0)
                {
                    usu.personas = null;
                    db.usuarios.Add(usu);

                    db.SaveChanges();
                }
                else
                {
                    return false;

                }

                int ids = usu.id_us;
                string cor = usu.usuario;

                List<personas> list = persona.Cast<personas>().ToList();


                personas per = list[0];
                List<tarjetas> listTar = per.tarjetas.Cast<tarjetas>().ToList();
                tarjetas tar = listTar[0];
                var nose = db.tarjetas.Where(y => y.numero_cuenta == tar.numero_cuenta).Count();
                var adios = db.personas.Where(x => x.documento == per.documento).Count();
                if (adios == 0 && nose == 0)
                {
                    per.usuario_id_us = ids;
                    per.correo = cor;
                    db.personas.Add(per);
                    db.SaveChanges();
                }
                else
                {
                    return false;
                }


                return true;
            }


            catch (Exception e)
            {

                Console.WriteLine(e.Message);

                return false;
            }

        }

        public static bool Actualizar(int id, [FromBody] usuarios usu)

        {
            dbglovoEntities1 db = new dbglovoEntities1();
            try
            {
                db.Entry(usu).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool EliminarUsuario(int id)
        {
            dbglovoEntities1 db = new dbglovoEntities1();

            try
            {
                db.usuarios.Remove(db.usuarios.Find(id));
                db.SaveChanges();
                return true;
            }

            catch
            {
                return false;
            }
        }

        public static bool CrearUsuario([FromBody] usuarios usu)
        {
            dbglovoEntities1 db = new dbglovoEntities1();
            var correo = usu.usuario;
            var hola = db.usuarios.Where(X => X.usuario == correo).Count();
            if (hola == 0)
            {

                db.usuarios.Add(usu);
                db.SaveChanges();
            }
            else
            {
                return false;
            }
            return true;



        }

    }
}