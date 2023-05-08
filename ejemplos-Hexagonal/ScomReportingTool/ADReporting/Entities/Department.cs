using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADReporting.Entities
{
    public class Department
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DepartmentID { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<ScomObject>? ScomObjects { get; set; }

        [ForeignKey("CustomerID")]
        public int CustomerID { get; set; }
    }
}
