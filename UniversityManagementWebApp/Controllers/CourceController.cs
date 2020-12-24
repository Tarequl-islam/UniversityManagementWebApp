using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementWebApp.Manager;
using UniversityManagementWebApp.Models;

namespace UniversityManagementWebApp.Controllers
{
    public class CourceController : Controller
    {
        private CourceManager courceManager;
        private DepartmentManager departmentManager;

        public CourceController()
        {
            courceManager = new CourceManager();
            departmentManager = new DepartmentManager();

        }
        [HttpGet]
        public ActionResult Save()
        {
            ViewBag.Departments = departmentManager.GetAllDepartmentForDropdown();
            ViewBag.Semisters = courceManager.GetAllSemisterForDropdown();
            return View();
        }
        [HttpPost]
        public ActionResult Save(Cource cource)
        {
            ViewBag.Departments = departmentManager.GetAllDepartmentForDropdown();
            ViewBag.Semisters = courceManager.GetAllSemisterForDropdown();
            if (ModelState.IsValid)
            {
                string messege = courceManager.Save(cource);
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