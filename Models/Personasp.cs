using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using AppGlovo.Transfers;
using System.Web.Http;

namespace AppGlovo.Models
{
    public partial class personas
    {
        public static bool ModificarGLover(int id, [FromBody] personas per)
        {

            dbglovoEntities1 db = new dbglovoEntities1();
            try
            {
                db.Entry(per).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch
            {

                return false;
            }


        }
        public static bool EliminarGlover(int id)
        {
            dbglovoEntities1 db = new dbglovoEntities1();

            try
            {
                db.personas.Remove(db.personas.Find(id));
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