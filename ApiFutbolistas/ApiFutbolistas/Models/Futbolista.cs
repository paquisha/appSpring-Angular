using System.ComponentModel.DataAnnotations;

namespace ApiFutbolistas.Models
{
    public class Futbolista
    {
        [Key]
        public int id { get; set; }
        public string nombre { get; set; }
        public string posicion { get; set; }
        public string nacionalidad { get; set; }
        public string imagen { get; set; }
    }
}
