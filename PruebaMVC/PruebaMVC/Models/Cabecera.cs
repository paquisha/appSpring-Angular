using System;
using System.Collections.Generic;

namespace PruebaMVC.Models
{
    public partial class Cabecera
    {
        public int IdCabecera { get; set; }
        public string? NombreCliente { get; set; }
        public string? NombreEmpresa { get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
    }
}
