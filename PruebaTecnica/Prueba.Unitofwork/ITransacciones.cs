using Prueba.ORM.Implementacion;

namespace Prueba.Unitofwork
{
    public interface ITransacciones
    {
        ProductoRepositorio ProductosRepositorio { get; }

        ProductoDetalleRepositorio ProductosDetalleRepositorio { get; }

        void Save();
    }
}