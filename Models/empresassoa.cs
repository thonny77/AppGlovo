using AppGlovo.Transfers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppGlovo.Models
{
    public partial class empresas
    {
        public static IEnumerable<empresasdt> ListadoEmpresas()  // ----> listar empresas 
        {
            dbglovoEntities1 db = new dbglovoEntities1();
            var list = from b in db.empresas.Where(t => t.id_empresa > 0).ToList()
                       select new empresasdt()
                       {
                           id_empresa = b.id_empresa,
                           nombres = b.nombres,
                           documento = b.documento,
                           cbu = b.cbu,
                           pais = b.pais,
                           categoria_id = b.categoria_id,
                           usuario_id_us = b.usuario_id_us,
                           correo_empresa = b.correo_empresa,
                       };
            return list;

        }
        public static IEnumerable<empresasdt> BuscarCategoria(int id)
        {
            dbglovoEntities1 db = new dbglovoEntities1();
            var list = from b in db.empresas.Where(t => t.categoria_id == id).ToList()
                       select new empresasdt()
                       {
                           id_empresa = b.id_empresa,
                           nombres = b.nombres,
                           documento = b.documento,
                           cbu = b.cbu,
                           pais = b.pais,
                           categoria_id = b.categoria_id,
                           usuario_id_us = b.usuario_id_us,
                           correo_empresa = b.correo_empresa,

                       };
            return list;


        }
        public static bool RegistrarEmpresa(empresas emp)
        {
            dbglovoEntities1 db = new dbglovoEntities1();
            try
            {

                var documento = emp.documento;
                var cbu = emp.cbu;
                var validar = db.empresas.Where(x => x.documento == documento).Count();
                var validar2 = db.empresas.Where(y => y.cbu == cbu).Count();

                if (documento != "" && cbu != "" && validar == 0 && validar2 == 0)
                {
                    db.empresas.Add(emp);
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }

            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;

            }


        }


        public static bool BorrarEmpresa(int id)    //-----eliminar empresas por id ingresado
        {
            dbglovoEntities1 db = new dbglovoEntities1();

            try
            {
                var del = db.empresas.Find(id);
                db.empresas.Remove(del);
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