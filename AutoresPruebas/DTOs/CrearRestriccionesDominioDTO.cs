using System.ComponentModel.DataAnnotations;

namespace AutoresPruebas.DTOs
{
    public class CrearRestriccionesDominioDTO
    {
        public int LlaveId { get; set; }
        [Required]
        public string Dominio { get; set; }
    }
}
