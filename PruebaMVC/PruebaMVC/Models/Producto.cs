using System;
using System.Collections.Generic;

namespace PruebaMVC.Models
{
    public partial class Producto
    {
        public int Codigo { get; set; }
        public string? Descripcion { get; set; }
        public int? Cantidad { get; set; }
        public decimal? Precio { get; set; }
        public decimal? Total { get; set; }
    }
}
