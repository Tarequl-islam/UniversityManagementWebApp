using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementWebApp.Manager;
using UniversityManagementWebApp.Models;

namespace UniversityManagementWebApp.Controllers
{
    public class DepartmentController : Controller
    {
        private DepartmentManager departmentManager;

        public DepartmentController()
        {
            departmentManager = new DepartmentManager();

        }
        [HttpGet]
        public ActionResult Save()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Save(Department department)
        {
            if (ModelState.IsValid)
            {
                string messege = departmentManager.Save(department);
                ViewBag.Messege = messege;
                if (messege == "Save successfull")
                {
                    ModelState.Clear();
                }
            }
            else
            {
                ViewBag.Messege = "Model State Invalid";
            }
           
            return View();
        }
	}
}