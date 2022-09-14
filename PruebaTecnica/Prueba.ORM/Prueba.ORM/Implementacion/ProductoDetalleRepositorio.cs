using Prueba.ORM.Effitec;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba.ORM.Implementacion
{
    public class ProductoDetalleRepositorio
    {
        private readonly effitecContext _context;

        public ProductoDetalleRepositorio(effitecContext context)
        {
            _context = context;
        }

        public List<ProductoDetalle> Get()
        {
            return _context.ProductoDetalles.ToList();
        }
        public ProductoDetalle GetById(int id)
        {
            return _context.ProductoDetalles.Find(id);
        }
        public void Agregar(ProductoDetalle obj)
        {
            _context.ProductoDetalles.Add(obj);
        }
        public void Modificar(ProductoDetalle obj)
        {
            _context.ProductoDetalles.Update(obj);
        }
        public void Eliminar(int id)
        {
            var obj = GetById(id);
            _context.ProductoDetalles.Remove(obj);
        }
        public void SaveChange()
        {
            _context.SaveChanges();
        }

    }
}
