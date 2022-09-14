using Prueba.Entitys;
using Prueba.ORM.Effitec;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Prueba.Logica.Interfaces
{
    public interface IProductosServicios
    {
        #region Productos

        List<Producto> GetListaProducto();
        Producto GetProductoById(int id);
        void AgregarProducto(ProductoRequest obj);
        void ModificarProducto(Producto obj);
        void EliminarProducto(int id);

        #endregion

        #region ProductosDetalle

        List<ProductoDetalle> GetListaProductoDetalle();
        ProductoDetalle GetProductoDetalleById(int id);
        void AgregarProductoDetalle(ProductoDetalle obj);
        void ModificarProductoDetalle(ProductoDetalle obj);
        void EliminarProductoDetalle(int id);

        #endregion

        Task<List<AllProductos>> GetListaInventario();
        Task<AllProductos> GetInventarioById(int id);
    }
}
