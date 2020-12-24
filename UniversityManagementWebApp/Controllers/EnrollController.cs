using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementWebApp.Manager;
using UniversityManagementWebApp.Models;

namespace UniversityManagementWebApp.Controllers
{
    public class EnrollController : Controller
    {
        private EnrollManager enrollManager;
        private CourceAssignManager courceAssignManager;

        public EnrollController()
        {
            enrollManager = new EnrollManager();
            courceAssignManager= new CourceAssignManager();

        }
        [HttpGet]
        public ActionResult Save()
        {
            ViewBag.Students = enrollManager.GetAllStudentForDropdown();
            ViewBag.Cources = enrollManager.GetAllCourceForDropdown();
            return View();
        }
        [HttpPost]
        public ActionResult Save(Enroll enroll)
        {
            ViewBag.Students = enrollManager.GetAllStudentForDropdown();
            ViewBag.Cources = enrollManager.GetAllCourceForDropdown();

            if (ModelState.IsValid)
            {
                string messege = enrollManager.Save(enroll);
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
        public JsonResult GetSelectedStudent(int stdId)
        {

            Enroll student = enrollManager.GetSelectedStudent(stdId);
            return Json(student);
        }
        //public JsonResult GetSelectedCource(int deptId)
        //{
        //    List<CourceAssign> cource = courceAssignManager.GetSelectedCource(deptId);
        //    ViewBag.cource = cource;
        //    return Json(cource);
        //}
	}
}