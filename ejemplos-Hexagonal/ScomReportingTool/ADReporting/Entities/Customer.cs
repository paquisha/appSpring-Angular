using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADReporting.Entities
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerID { get; set; }
        public string? Name { get; set; }
        public string? Ruc { get; set; }
        public virtual ICollection<ContactUser>? ContactUsers { get; set; }
        public virtual ICollection<AttentionSchedule>? AttentionSchedules { get; set; }
    }
}
