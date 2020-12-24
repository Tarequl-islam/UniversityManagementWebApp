using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Mime;
using System.Web;

namespace UniversityManagementWebApp.Models
{
    public class CourceAssign
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }
        [Required]
        [Display(Name = "Teacher")]
        public int TeacherId { get; set; }
        public string TeacherName { get; set; }
        [Display(Name = "Credit To be Taken")]
        public double Credit { get; set; }
        public double RemaningCredit { get; set; }
        [Required]
        [Display(Name = "Cource")]
        public int CourceId { get; set; }
        [Display(Name = "Cource Code")]
        public string CourceCode { get; set; }
        public string CourceName { get; set; }
        public double CourceCredit { get; set; }
        public int Flag { get; set; }

        public CourceAssign()
        {
            Flag = 1;
        }
    }
}
