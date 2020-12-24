using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementWebApp.Manager;
using UniversityManagementWebApp.Models;

namespace UniversityManagementWebApp.Controllers
{
    public class ResultController : Controller
    {
            private EnrollManager enrollManager;
            private CourceAssignManager courceAssignManager;

            public ResultController()
            {
                enrollManager = new EnrollManager();
                courceAssignManager = new CourceAssignManager();

            }
            [HttpGet]
            public ActionResult Save()
            {
                ViewBag.Students = enrollManager.GetAllStudentForDropdown();
                ViewBag.Cources = enrollManager.GetAllCourceForDropdown();
                ViewBag.Grades = enrollManager.GetAllGradesForDropdown();
                return View();
            }
            [HttpPost]
            public ActionResult Save(Result enroll)
            {
                ViewBag.Students = enrollManager.GetAllStudentForDropdown();
                ViewBag.Cources = enrollManager.GetAllCourceForDropdown();
                ViewBag.Grades = enrollManager.GetAllGradesForDropdown();

                if (ModelState.IsValid)
                {
                    string messege = enrollManager.SaveResult(enroll);
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
