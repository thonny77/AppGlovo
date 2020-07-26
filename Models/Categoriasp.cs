using AppGlovo.Transfers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppGlovo.Models
{
    public partial class categorias
    {

        public static IEnumerable<categoriasDTO> CategoryByTipo(string tipo)

        {
            dbglovoEntities1 db = new dbglovoEntities1();

            var list = from b in db.categorias
                       where (b.tipo.Contains(tipo))
                       select new categoriasDTO()
                       {
                           id= b.id,
                           nombre_categoria =b.nombre_categoria,
                           descripcion = b.descripcion,
                           tipo = b.tipo,
                       };

            return list;
        }

        public static IEnumerable<categoriasDTO> ListarCatgDescripcion(string descripcion)
        {
            dbglovoEntities1 db = new dbglovoEntities1();

            var list = from b in db.categorias.Where(t => t.descripcion == descripcion).ToList()
                       select new categoriasDTO()
                       {
                           id = b.id,
                           nombre_categoria = b.nombre_categoria,
                           descripcion = b.descripcion,
                           tipo = b.tipo
                       };
            return list;
        }

    }
}