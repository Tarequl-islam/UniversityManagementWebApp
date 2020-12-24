using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementWebApp.Manager;
using UniversityManagementWebApp.Models;

namespace UniversityManagementWebApp.Controllers
{
    public class TeacherController : Controller
    {
        private TeacherManager teacherManager;
        private DepartmentManager departmentManager;

        public TeacherController()
        {
            teacherManager = new TeacherManager();
            departmentManager = new DepartmentManager();

        }
        [HttpGet]
        public ActionResult Save()
        {
            ViewBag.Departments = departmentManager.GetAllDepartmentForDropdown();
            ViewBag.Designations = teacherManager.GetAllDesinationForDropdown();
            return View();
        }
        [HttpPost]
        public ActionResult Save(Teacher teacher)
        {
            ViewBag.Departments = departmentManager.GetAllDepartmentForDropdown();
            ViewBag.Designations = teacherManager.GetAllDesinationForDropdown();
            if (ModelState.IsValid)
            {
                teacher.RemaningCradit = teacher.Credit;
                string messege = teacherManager.Save(teacher);
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