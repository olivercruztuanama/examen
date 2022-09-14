using Microsoft.VisualStudio.TestTools.UnitTesting;
using Prueba.Logica.Interfaces;
using Prueba.ORM.Effitec;

namespace Prueba.Test
{
    [TestClass]
    public class UnitTest1
    {
        private IProductosServicios _productosServicios;
        public UnitTest1(IProductosServicios productosServicios)
        {
            _productosServicios = productosServicios;
        }

        [TestMethod]
        public void TestMethod1()
        {
            var obj = new Producto() { };
            var resultado = _productosServicios.GetProductoById(1);
            Assert.AreEqual(obj, resultado);
        }
    }
}