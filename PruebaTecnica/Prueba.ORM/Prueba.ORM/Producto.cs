using System;
using System.Collections.Generic;

#nullable disable

namespace Prueba.ORM
{
    public partial class Producto
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int? Estado { get; set; }
    }
}
