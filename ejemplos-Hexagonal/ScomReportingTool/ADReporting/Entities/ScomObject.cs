﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADReporting.Entities
{
    public class ScomObject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ObjectID { get; set; }
        public string? Name { get; set; }
        public string? Path { get; set; }
        public string? Type { get; set; }
        [ForeignKey("DepartmentID")]
        public int DepartmentID { get; set; }
    }
}
