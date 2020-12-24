using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;
using UniversityManagementWebApp.Manager;
using UniversityManagementWebApp.Models;

namespace UniversityManagementWebApp.Controllers
{
    public class CourceAssignController : Controller
    {
        private TeacherManager teacherManager;
        private DepartmentManager departmentManager;
        private CourceAssignManager courceAssignManager;

        public CourceAssignController()
        {
            teacherManager = new TeacherManager();
            departmentManager = new DepartmentManager();
            courceAssignManager= new CourceAssignManager();

        }
        [HttpGet]
        public ActionResult Save()
        {
            ViewBag.Departments = departmentManager.GetAllDepartmentForDropdown();
            return View();
        }
        [HttpPost]
        public ActionResult Save(CourceAssign courceAssign)
        {
            ViewBag.Departments = departmentManager.GetAllDepartmentForDropdown();
            if (ModelState.IsValid && courceAssign.TeacherId != 0 && courceAssign.CourceId != 0)
            {
                if (courceAssign.RemaningCredit < courceAssign.CourceCredit)
                {
                    ViewBag.alertMsg = "You are entering more than teachers remaining credit";
                }
                string messege = courceAssignManager.Save(courceAssign);
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
        public JsonResult GetSelectedTeacher(int deptId)
        {
            List<CourceAssign> teachers = courceAssignManager.GetSelectedTeacher(deptId);
            ViewBag.teacher = teachers;
            return Json(teachers);
        }
        public JsonResult GetSelectedCource(int deptId)
        {
            List<CourceAssign> cource = courceAssignManager.GetSelectedCource(deptId);
            ViewBag.cource = cource;
            return Json(cource);
        }
        public JsonResult GetTeacherId(int teacherId)
        {
            //List<CourceAssign> teacher = ViewBag.teacher;
            //var tchr = teacher.Find(x => x.TeacherId == teacherId); 
            CourceAssign courceAssign = courceAssignManager.GetTeacherDetails(teacherId);
            return Json(courceAssign);
        }
        public JsonResult GetCourceId(int courceId)
        {
            //List<CourceAssign> cource = ViewBag.cource;
            //var crce = cource.Find(x => x.CourceId == courceId);
            CourceAssign courceAssign = courceAssignManager.GetCourceDetails(courceId);
            return Json(courceAssign);
        }
	}
}