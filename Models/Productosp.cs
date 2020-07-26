using AppGlovo.Transfers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace AppGlovo.Models
{
    public partial class Productos
    {

        public static IEnumerable<productosdt> ListAll(int id) 
        {
            dbglovoEntities1 db = new dbglovoEntities1();
            
            var list = from b in db.productos
                       join c in db.categorias on b.categoria_id equals c.id
                       where (c.tipo.Contains("2"))
                       where (c.id == id)

                       select new productosdt()
                       {
                           //sku, nombre, descripcion, foto, categoria_id, stock
                           sku = b.sku,
                           nombre = b.nombre,
                           descripcion = b.descripcion,
                           foto = b.foto,
                           categoria_id = b.categoria_id,
                           stock = b.stock,
                           precio= b.precio,
                           precio_promo= b.precio_promo,
                           fv_promo=b.fv_promo,
                           codigo_producto= b.codigo_producto


                       };
            return list;
        }
        public static IEnumerable<productosdt> ProdByCat(string cat)

        {
            dbglovoEntities1 db = new dbglovoEntities1();

            var list = from p in db.productos
                        join c in db.categorias on p.categoria_id equals c.id 

                        where (c.nombre_categoria.Contains(cat) )

                        select new productosdt
                        {
                            sku = p.sku,
                            nombre = p.nombre,
                            precio = p.precio,
                            descripcion=p.descripcion,
                            precio_promo = p.precio_promo,
                            fv_promo = p.fv_promo,
                            codigo_producto = p.codigo_producto
                        };
            return list;
        }


        public static IEnumerable<productosdt> ListarProducto()
        {
            dbglovoEntities1 db = new dbglovoEntities1();
            var list = from b in db.productos.Where(t => t.stock > 0).ToList()
                       select new productosdt()
                       {
                           sku = b.sku,
                           nombre = b.nombre,
                           descripcion = b.descripcion,
                           precio = b.precio,
                           foto = b.foto,
                           categoria_id = b.categoria_id,
                           precio_promo = b.precio_promo,
                           fv_promo = b.fv_promo,
                           stock = b.stock,
                       };
            return list;
        }

        public static IEnumerable<productosdt> BuscarXCategoria(string nombre_categoria)
        {
            dbglovoEntities1 db = new dbglovoEntities1();


            var list = from p in db.productos
                       join c in db.categorias on p.categoria_id equals c.id
                       where (c.nombre_categoria.Contains(nombre_categoria))

                       select new productosdt()
                       {
                           sku = p.sku,
                           nombre = p.nombre,
                           descripcion = p.descripcion,
                           precio = p.precio,
                           foto = p.foto,
                           categoria_id = p.categoria_id,
                           precio_promo = p.precio_promo,
                           fv_promo = p.fv_promo,

                       };
            return list;
        }

        public static IEnumerable<categoriasDTO> BuscarxEmpresa(string nombres)
        {
            dbglovoEntities1 db = new dbglovoEntities1();


            var list = from c in db.categorias
                       join e in db.empresas on c.id equals e.categoria_id
                       where (e.nombres.Contains(nombres))
                       select new categoriasDTO()
                       {
                           id = c.id,
                           nombre_categoria = c.nombre_categoria,
                           descripcion = c.descripcion,
                           tipo = c.tipo

                       };
            return list;
        }

        public static IEnumerable<productosdt> Buscar(string nombre)
        {
            dbglovoEntities1 db = new dbglovoEntities1();


            var list = from b in db.productos.Where(t => t.nombre.Contains(nombre)).ToList()
                       select new productosdt()
                       {
                           sku = b.sku,
                           nombre = b.nombre,
                           descripcion = b.descripcion,
                           precio = b.precio,
                           foto = b.foto,
                           categoria_id = b.categoria_id,
                           precio_promo = b.precio_promo,
                           fv_promo = b.fv_promo,
                           stock = b.stock,
                       };
            return list;
        }
        public static IEnumerable<productosdt> BuscarCategoria_id(int categoria_id)
        {
            dbglovoEntities1 db = new dbglovoEntities1();

            var list = from b in db.productos.Where(t => t.categoria_id == categoria_id).ToList()

                       select new productosdt()
                       {
                           sku = b.sku,
                           nombre = b.nombre,
                           descripcion = b.descripcion,
                           precio = b.precio,
                           foto = b.foto,
                           categoria_id = b.categoria_id,
                           precio_promo = b.precio_promo,
                           fv_promo = b.fv_promo,

                       };
            return list;
        }

        public static bool Insert(productos p)
        {
            dbglovoEntities1 db = new dbglovoEntities1();
            var sku = p.codigo_producto;
            var validar = db.productos.Where(x => x.codigo_producto == sku).Count();
            if (validar == 0)
            {
                try
                {
                    db.productos.Add(p);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return false;
                }
            }
            else 
            {
                return false;
            }
        }

            public static bool Delete(int id)
            {
                dbglovoEntities1 db = new dbglovoEntities1();
                try
                {
                    var ids = db.productos.Find(id);
                    db.productos.Remove(ids);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return false; 
                }
            }

        public static bool ActualizarProducto(int id, [FromBody] productos pro)
        {
            dbglovoEntities1 db = new dbglovoEntities1();

            try
            {
                db.Entry(pro).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch

            {
                return false;
            }
        }

        public static bool EliminarProducto(int id)
        {
            dbglovoEntities1 db = new dbglovoEntities1();
            try
            {
                db.productos.Remove(db.productos.Find(id));
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