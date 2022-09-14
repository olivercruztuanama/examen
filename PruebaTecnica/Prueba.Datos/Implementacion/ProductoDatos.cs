using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Prueba.Datos.Interfaces;
using Prueba.Entitys;
using Prueba.ORM.Effitec;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Prueba.Datos.Implementacion
{
    public class ProductoDatos : IProductoDatos
    {
        private readonly string _connectionString;
        public ProductoDatos(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Database");
        }

        public async Task<List<AllProductos>> GetLista()
        {
            var resultado = new List<AllProductos>();
            string query = "ListarProductosPorId";

            using (IDbConnection conexion = new SqlConnection(_connectionString))
            {
                conexion.Open();
                DynamicParameters Params = new DynamicParameters();
                Params.Add("@id", 0);
                var result = await conexion.QueryAsync<AllProductos>(query, Params, commandType: CommandType.StoredProcedure).ConfigureAwait(false);
                resultado = result.AsList();
            }

            return resultado;
        }

        public async Task<AllProductos> GetById(int id)
        {
            var resultado = new AllProductos();
            string query = "ListarProductosPorId";

            using (IDbConnection conexion = new SqlConnection(_connectionString))
            {
                conexion.Open();
                DynamicParameters Params = new DynamicParameters();
                Params.Add("@id", id);
                var result = await conexion.QueryAsync<AllProductos>(query, param: Params, commandType: CommandType.StoredProcedure).ConfigureAwait(false);
                resultado = (AllProductos)result;
            }

            return resultado;
        }
    }
}
