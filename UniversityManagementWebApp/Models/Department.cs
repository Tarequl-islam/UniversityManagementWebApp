using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UniversityManagementWebApp.Models
{
    public class Department
    {
        public int Id { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 2)]
        [Column(TypeName = "varchar")]
        public string Name { get; set; }
        [Required]
        [StringLength(7, MinimumLength = 2)]
        public string Code { get; set; }
        public int Flag { get; set; }

        public Department()
        {
            Flag = 1;
        }
    }
}