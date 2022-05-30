using System;
using System.Collections.Generic;

namespace PruebaMVC.Models
{
    public partial class Detalle
    {
        public int Codigo { get; set; }
        public int IdCabecera { get; set; }
        public string? Vendedor { get; set; }
        public string? OrdenCompra { get; set; }
        public string? Enviar { get; set; }
        public string? Terminos { get; set; }

        public virtual Producto CodigoNavigation { get; set; } = null!;
        public virtual Cabecera IdCabeceraNavigation { get; set; } = null!;
    }
}
