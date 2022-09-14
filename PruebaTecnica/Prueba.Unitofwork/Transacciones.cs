using Prueba.ORM.Effitec;
using Prueba.ORM.Implementacion;

namespace Prueba.Unitofwork
{
    public class Transacciones : ITransacciones
    {
        private effitecContext _context;
        private ProductoRepositorio _productoRepositorio;
        private ProductoDetalleRepositorio _productoDetalleRepositorio;
        
        public Transacciones(effitecContext context)
        {
            _context = context;
        }

        public ProductoRepositorio ProductosRepositorio
        {
            get
            {
                if (_productoRepositorio == null)
                {
                    _productoRepositorio = new ProductoRepositorio(_context);
                }
                return _productoRepositorio;
            }
        }

        public ProductoDetalleRepositorio ProductosDetalleRepositorio
        {
            get
            {
                if (_productoDetalleRepositorio == null)
                {
                    _productoDetalleRepositorio = new ProductoDetalleRepositorio(_context);
                }
                return _productoDetalleRepositorio;
            }
        }

        public void Save()
        {
            _productoRepositorio.SaveChange();
        }
    }
}
