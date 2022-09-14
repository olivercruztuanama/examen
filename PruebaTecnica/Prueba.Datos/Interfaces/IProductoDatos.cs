using Prueba.Entitys;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Prueba.Datos.Interfaces
{
    public interface IProductoDatos
    {
        Task<List<AllProductos>> GetLista();
        Task<AllProductos> GetById(int id);
    }
}
