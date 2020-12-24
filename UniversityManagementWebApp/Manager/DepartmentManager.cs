using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementWebApp.Gateway;
using UniversityManagementWebApp.Models;

namespace UniversityManagementWebApp.Manager
{
    public class DepartmentManager
    {
        private DepartmentGatway departmentGatway;

        public DepartmentManager()
        {
            departmentGatway = new DepartmentGatway();
        }

        public string Save(Department department)
        {
            if (departmentGatway.IsDepartmentExist(department.Name, department.Code))
            {
                return "This Cource is already Exist. Please retry";
            }
            else
            {
                int rowAffect = departmentGatway.Save(department);

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

        public List<Department> GetAllDepartments()
        {
            return departmentGatway.GetAllDepartments();
        }

        public List<SelectListItem> GetAllDepartmentForDropdown()
        {
            List<Department> departments = GetAllDepartments();
            List<SelectListItem> selectListItems = new List<SelectListItem>()
            {
                new SelectListItem()
                {
                    Text = "--Select--",
                    Value = ""
                }
            };
            foreach (Department department in departments)
            {
                SelectListItem selectListItem = new SelectListItem();
                selectListItem.Text = department.Name;
                selectListItem.Value = department.Id.ToString();
                selectListItems.Add(selectListItem);
            }
            return selectListItems;
        }
    }
}