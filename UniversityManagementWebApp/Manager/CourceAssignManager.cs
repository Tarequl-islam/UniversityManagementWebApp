using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementWebApp.Gateway;
using UniversityManagementWebApp.Models;

namespace UniversityManagementWebApp.Manager
{
    public class CourceAssignManager
    {
        private CourceAssignGateway courceAssignGateway;

        public CourceAssignManager()
        {
            courceAssignGateway = new CourceAssignGateway();
        }

        public string Save(CourceAssign courceAssign)
        {
            if (courceAssignGateway.IsCourceAssignExist(courceAssign.DepartmentId, courceAssign.TeacherId, courceAssign.CourceId))
            {
                return "This Cource is already Assigned to this teacher. Please retry";
            }
            else
            {
                int rowAffect = courceAssignGateway.Save(courceAssign);
                int updateMessege = courceAssignGateway.UpdateCredit(courceAssign);

                if (rowAffect > 0 && updateMessege > 0)
                {
                    return "Save successfull";
                }
                else
                {
                    return "Save failed";
                }
            }

        }
        public List<CourceAssign> GetSelectedTeacher(int departmentId)
        {
            return courceAssignGateway.GetSelectedTeacher(departmentId);
        }

        public List<CourceAssign> GetSelectedCource(int departmentId)
        {
            return courceAssignGateway.GetSelectedCource(departmentId);
        }

        public CourceAssign GetTeacherDetails(int teacherId)
        {
            return courceAssignGateway.GetTeacherDetails(teacherId);
        }

        public CourceAssign GetCourceDetails(int courceId)
        {
            return courceAssignGateway.GetCourceDetails(courceId);
        }
    }
}