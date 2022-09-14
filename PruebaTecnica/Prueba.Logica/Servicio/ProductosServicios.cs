using AutoMapper;
using Prueba.Datos.Interfaces;
using Prueba.Entitys;
using Prueba.Logica.Interfaces;
using Prueba.ORM.Effitec;
using Prueba.Unitofwork;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Prueba.Logica.Servicio
{
    public class ProductosServicios : IProductosServicios
    {
        private readonly ITransacciones _transacciones;
        private readonly IProductoDatos _productoDatos;
        private readonly IMapper _mapper;

        public ProductosServicios(ITransacciones transacciones, IProductoDatos productoDatos)
        {
            _transacciones = transacciones;
            _productoDatos = productoDatos;
        }

        #region Producto

        public List<Producto> GetListaProducto()
        {
            return _transacciones.ProductosRepositorio.Get();
        }
        public Producto GetProductoById(int id)
        {
            return _transacciones.ProductosRepositorio.GetById(id);
        }
        public void AgregarProducto(ProductoRequest obj)
        {
            var mapper = _mapper.Map<Producto>(obj);
            _transacciones.ProductosRepositorio.Agregar(mapper);
            _transacciones.Save();
        }
        public void ModificarProducto(Producto obj)
        {
            _transacciones.ProductosRepositorio.Modificar(obj);
            _transacciones.Save();
        }
        public void EliminarProducto(int id)
        {
            _transacciones.ProductosRepositorio.Eliminar(id);
            _transacciones.Save();
        }

        #endregion

        #region Detalle Producto

        public List<ProductoDetalle> GetListaProductoDetalle()
        {
            return _transacciones.ProductosDetalleRepositorio.Get();
        }
        public ProductoDetalle GetProductoDetalleById(int id)
        {
            return _transacciones.ProductosDetalleRepositorio.GetById(id);
        }
        public void AgregarProductoDetalle(ProductoDetalle obj)
        {
            _transacciones.ProductosDetalleRepositorio.Agregar(obj);
            _transacciones.Save();
        }
        public void ModificarProductoDetalle(ProductoDetalle obj)
        {
            _transacciones.ProductosDetalleRepositorio.Modificar(obj);
            _transacciones.Save();
        }
        public void EliminarProductoDetalle(int id)
        {
            _transacciones.ProductosDetalleRepositorio.Eliminar(id);
            _transacciones.Save();
        }

        #endregion

        #region Inventario

        public Task<List<AllProductos>> GetListaInventario()
        {
            return _productoDatos.GetLista();
        }
        public Task<AllProductos> GetInventarioById(int id)
        {
            return _productoDatos.GetById(id);
        }

        #endregion
    }
}
