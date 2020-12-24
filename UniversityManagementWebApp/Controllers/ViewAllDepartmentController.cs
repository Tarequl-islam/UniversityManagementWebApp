using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementWebApp.Manager;
using UniversityManagementWebApp.Models;

namespace UniversityManagementWebApp.Controllers
{
    public class ViewAllDepartmentController : Controller
    {

        private DepartmentManager departmentManager;

        public ViewAllDepartmentController()
        {
            departmentManager=new DepartmentManager();
        }
        //
        // GET: /ViewAllDepartment/
        public ActionResult ViewAll()
        {
            List<Department> departmentList = departmentManager.GetAllDepartments();
            return View(departmentList);
        }
	}
}