using AppGlovo.Models;
using AppGlovo.Transfers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Routing;

namespace AppGlovo.Controllers
{
    public class ProductosController : ApiController
    {

        //listar productos
        [HttpGet]
        [Route("api/BusquedaProducto/ListarProducto")]
        public IEnumerable<productosdt> Get()
        {
            return Productos.ListarProducto();

        }

        //Listar Producto por categoria
        //api/BusquedaProducto/BuscarXCategoria?nombre_categoria=comida
        [HttpGet]
        [Route("api/BusquedaProducto/BuscarXCategoria")]
        public IEnumerable<productosdt> BuscarXCategoria(string nombre_categoria)
        {

            return Productos.BuscarXCategoria(nombre_categoria);

        }

         
        //Listar producto por empresa
        //api/BusquedaProducto/BuscarxEmpresa?nombres=kfc
        //[Authorize]        
        [HttpGet]
        [Route("api/BusquedaProducto/BuscarxEmpresa")]
        public IEnumerable<categoriasDTO> Get(string nombres)
        {
            return Productos.BuscarxEmpresa(nombres);
        }

             
        //busqueda de producto por nombre
        [HttpGet]
        [Route("api/BusquedaProducto/Buscar")]
        public IEnumerable<productosdt> Buscar(string nombre)
        {

            return Productos.Buscar(nombre);

        }


        [HttpGet]
        [Route("api/BusquedaProducto/ListarCatgDescripcion")]
        public IEnumerable<categoriasDTO> ListarCatgDescripcion(string descrpcion)
        {

            return categorias.ListarCatgDescripcion(descrpcion);

        }

        [HttpGet]
        [Route("api/BusquedaProducto/ListarCategoria")]
        public IEnumerable<categoriasDTO> ListarCategoria(string nombre_categoria)
        {

            return categorias.ListarCatgDescripcion(nombre_categoria);

        }

        [HttpGet]
        [Route("api/BusquedaProducto/BuscarCategoria_id")]
        public IEnumerable<productosdt> BuscarCategoria_id(int categoria_id)
        {

            return Productos.BuscarCategoria_id(categoria_id);

        }

        // POST: api/Productos
        public IEnumerable<productosdt> Get(int id)
        {
            return Productos.ListAll(id);
        }

        // POST: api/Productos
        public bool Post([FromBody] productos p)
        {
            return Productos.Insert(p);
        }

        // PUT: api/Productos/5
        public bool Put(int id, [FromBody] productos pro)
        {
            return Productos.ActualizarProducto(id, pro);
        }

        // DELETE: api/Productos/5
        public bool  Delete(int id)
        {
            return Productos.Delete(id);
        }
    }
}
