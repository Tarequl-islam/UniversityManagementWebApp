using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UniversityManagementWebApp.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 2)]
        [Column(TypeName = "varchar")]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [Phone]
        public string ContactNo { get; set; }
        [Required]
        [Display(Name = "Designation")]
        public string DesignationId { get; set; }
        [Required]
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }
        [Required]
        [Range(0.5, 18.0)]
        [Display(Name = "Cradit To be Taken")]
        public double Credit { get; set; }
        //[Required]
        //[Range(0.5, 5.0)]
        public double RemaningCradit { get; set; }
        public int Flag { get; set; }

        public Teacher()
        {
            Flag = 1;
            
        }
    }
}