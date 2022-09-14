using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NUnit.Framework;
using Prueba.Entitys;
using Prueba.ORM.Effitec;
using Prueba.ORM.Implementacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Prueba.Api.Test.Servicio
{
    public class ProductosServiciosTest
    {
        private Producto _producto;

        private IServiceProvider CreateContext(string namedatabase)
        {
            var services = new ServiceCollection();
            services.AddDbContext<effitecContext>(options => options.UseInMemoryDatabase(databaseName: namedatabase),
                ServiceLifetime.Scoped, ServiceLifetime.Scoped);
            return services.BuildServiceProvider();
        }

        [SetUp]
        public void Setup()
        {
            _producto = new Producto()
            {
                Id = 1,
                Descripcion = "Mesa",
                Precio = 100,
                Estado = 1
            };
        }

        [Test]
        public void Test1()
        {
            var nameDB = Guid.NewGuid().ToString();
            var serviceContext = CreateContext(nameDB);
            var db = serviceContext.GetService<effitecContext>();
            db.Add(_producto);
            
            ProductoRepositorio services = new ProductoRepositorio(db);
            var response = services.GetById(1);
            Assert.AreEqual(_producto, response);
        }
    }
}
