using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace UniversityManagementWebApp.Models
{
    public class Enroll
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Student Reg No")]
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string RegistNo { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }
        public int DepartmentId { get; set; }
        [Required]
        [Display(Name = "Select Cource")]
        public int CourceId { get; set; }
        [Required(ErrorMessage = "Please Select a Date")]
        public string Date { get; set; }
    }
}