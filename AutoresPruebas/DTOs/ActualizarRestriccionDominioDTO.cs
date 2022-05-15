using System.ComponentModel.DataAnnotations;

namespace AutoresPruebas.DTOs
{
    public class ActualizarRestriccionDominioDTO
    {
        [Required]
        public string Dominio { get; set; }
    }
}
