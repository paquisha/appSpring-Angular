using System.ComponentModel.DataAnnotations;

namespace ApiFutbolistas.Models
{
    public class GestoresDb
    {
        [Key]
        public int id { get; set; }
        public string nombre { get; set; }
        public string lanzamiento { get; set; }
        public string desarrollador { get; set; }
    }
}
