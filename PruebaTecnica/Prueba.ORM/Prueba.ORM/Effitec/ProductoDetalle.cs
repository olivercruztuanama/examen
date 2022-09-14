using System;
using System.Collections.Generic;

#nullable disable

namespace Prueba.ORM.Effitec
{
    public partial class ProductoDetalle
    {
        public int Iddet { get; set; }
        public int? Id { get; set; }
        public int? Cantidad { get; set; }
        public decimal? Total { get; set; }
        public DateTime? Fecharegistro { get; set; }
        public int? Estado { get; set; }

        public virtual Producto IdNavigation { get; set; }
    }
}
