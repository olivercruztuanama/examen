using Prueba.ORM.Effitec;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba.ORM.Implementacion
{
    public class ProductoRepositorio
    {
        private readonly effitecContext _context;

        public ProductoRepositorio(effitecContext context)
        {
            _context = context;
        }

        public List<Producto> Get()
        {
            return _context.Productos.ToList();
        }
        public Producto GetById(int id)
        {
            return _context.Productos.Find(id);
        }
        public void Agregar(Producto obj)
        {
            _context.Productos.Add(obj);
        }
        public void Modificar(Producto obj)
        {
            _context.Productos.Update(obj);
        }
        public void Eliminar(int id)
        {
            var obj = GetById(id);
            _context.Productos.Remove(obj);
        }
        public void SaveChange()
        {
            _context.SaveChanges();
        }

    }
}
