using System;
using System.Collections.Generic;

#nullable disable

namespace Prueba.ORM.Effitec
{
    public partial class Producto
    {
        public Producto()
        {
            ProductoDetalles = new HashSet<ProductoDetalle>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }
        public decimal? Precio { get; set; }
        public int? Estado { get; set; }

        public virtual ICollection<ProductoDetalle> ProductoDetalles { get; set; }
    }
}
