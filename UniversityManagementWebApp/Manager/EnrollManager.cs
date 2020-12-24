using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementWebApp.Gateway;
using UniversityManagementWebApp.Models;

namespace UniversityManagementWebApp.Manager
{
    public class EnrollManager
    {
        private EnrollGateway enrollGateway;

        public EnrollManager()
        {
            enrollGateway=new EnrollGateway();
        }

        public List<Enroll> GetAllStudents()
        {
            return enrollGateway.GetAllStudents();
        }
        public List<SelectListItem> GetAllStudentForDropdown()
        {
            List<Enroll> students = GetAllStudents();
            List<SelectListItem> selectListItems = new List<SelectListItem>()
            {
                new SelectListItem()
                {
                    Text = "--Select--",
                    Value = ""
                }
            };
            foreach (Enroll student in students)
            {
                SelectListItem selectListItem = new SelectListItem();
                selectListItem.Text = student.RegistNo;
                selectListItem.Value = student.Id.ToString();
                selectListItems.Add(selectListItem);
            }
            return selectListItems;
        }
        public Enroll GetSelectedStudent(int stdId)
        {
            return enrollGateway.GetSelectedStudent(stdId);
        }
        public List<Enroll> GetAllCources()
        {
            return enrollGateway.GetAllCources();
        }

        public List<SelectListItem> GetAllCourceForDropdown()
        {
            List<Enroll> cources = GetAllCources();
            List<SelectListItem> selectListItems = new List<SelectListItem>()
            {
                new SelectListItem()
                {
                    Text = "--Select--",
                    Value = ""
                }
            };
            foreach (Enroll cource in cources)
            {
                SelectListItem selectListItem = new SelectListItem();
                selectListItem.Text = cource.Name;
                selectListItem.Value = cource.Id.ToString();
                selectListItems.Add(selectListItem);
            }
            return selectListItems;
        }

        public string Save(Enroll enroll)
        {
            if (enrollGateway.IsCourceExist(enroll.StudentId, enroll.CourceId))
            {
                return "This Cource is already Exist. Please retry";
            }
            else
            {
                int rowAffect = enrollGateway.Save(enroll);

                if (rowAffect > 0)
                {
                    return "Save successfull";
                }
                else
                {
                    return "Save failed";
                }
            }

        }

        public List<Result> GetAllGrade()
        {
            return enrollGateway.GetAllGrades();
        }

        public List<SelectListItem> GetAllGradesForDropdown()
        {
            List<Result> cources = GetAllGrade();
            List<SelectListItem> selectListItems = new List<SelectListItem>()
            {
                new SelectListItem()
                {
                    Text = "--Select--",
                    Value = ""
                }
            };
            foreach (Result cource in cources)
            {
                SelectListItem selectListItem = new SelectListItem();
                selectListItem.Text = cource.GradeName;
                selectListItem.Value = cource.GradeId.ToString();
                selectListItems.Add(selectListItem);
            }
            return selectListItems;
        }

        public string SaveResult(Result enroll)
        {
            if (enrollGateway.IsResultExist(enroll.StudentId, enroll.CourceId))
            {
                return "This Cource is already Exist in The student's Result. Please retry";
            }
            else
            {
                int rowAffect = enrollGateway.SaveResult(enroll);

                if (rowAffect > 0)
                {
                    return "Save successfull";
                }
                else
                {
                    return "Save failed";
                }
            }

        }



    }
}