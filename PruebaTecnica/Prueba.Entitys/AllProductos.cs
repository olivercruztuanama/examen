using System;

namespace Prueba.Entitys
{
    public class AllProductos
    {
        public int IdDet { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        public decimal Total { get; set; }
        public DateTime Fecharegistro { get; set; }
        public int Estado { get; set; }
    }
}
