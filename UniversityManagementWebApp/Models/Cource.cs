using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Policy;
using System.Web;

namespace UniversityManagementWebApp.Models
{
    public class Cource
    {
        public int Id { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 2)]
        [Column(TypeName = "varchar")]
        public string Name { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 5)]
        public string Code { get; set; }
        [Required]
        [Range(0.5, 5.0)]
        public double Cradit { get; set; }
        [Required]
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }
        [Required]
        [Display(Name = "Semister")]
        public int SemisterId { get; set; }
        [Required]
        [Column(TypeName = "varchar")]
        public string Description { get; set; }
        public int Flag{ get; set; }

        public Cource()
        {
            Flag = 1;
        }

    }
}