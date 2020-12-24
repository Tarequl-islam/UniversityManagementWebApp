using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementWebApp.Gateway;
using UniversityManagementWebApp.Models;

namespace UniversityManagementWebApp.Manager
{
    public class TeacherManager
    {
        private TeacherGateway teacherGateway;

        public TeacherManager()
        {
            teacherGateway = new TeacherGateway();
        }

        public string Save(Teacher teacher)
        {
            if (teacherGateway.IsTeacherExist(teacher.Name))
            {
                return "This Cource is already Exist. Please retry";
            }
            else
            {
                int rowAffect = teacherGateway.Save(teacher);

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
        public List<Designation> GetAllSemister()
        {
            return teacherGateway.GetAllDesignations();
        }

        public List<SelectListItem> GetAllDesinationForDropdown()
        {
            List<Designation> designations = GetAllSemister();
            List<SelectListItem> selectListItems = new List<SelectListItem>()
            {
                new SelectListItem()
                {
                    Text = "--Select--",
                    Value = ""
                }
            };
            foreach (Designation designation in designations)
            {
                SelectListItem selectListItem = new SelectListItem();
                selectListItem.Text = designation.Name;
                selectListItem.Value = designation.Id.ToString();
                selectListItems.Add(selectListItem);
            }
            return selectListItems;
        }
    }
}