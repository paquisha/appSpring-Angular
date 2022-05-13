using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantAPI.Models
{
    public class Costumer
    {
        [Key]
        public int CostumerId { get; set; }

        [Column(TypeName="nvarchar(100)")]
        public string CostumerName { get; set; }
    }
}
