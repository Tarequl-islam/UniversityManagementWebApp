using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementWebApp.Gateway;
using UniversityManagementWebApp.Models;

namespace UniversityManagementWebApp.Manager
{
    public class CourceManager
    {
        private CourceGateway courceGateway;

        public CourceManager()
        {
            courceGateway=new CourceGateway();
        }

        public string Save(Cource cource)
        {
            if (courceGateway.IsCourceExist(cource.Name, cource.Code))
            {
                return "This Cource is already Exist. Please retry";
            }
            else
            {
                int rowAffect = courceGateway.Save(cource);

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
        public List<Semister> GetAllSemister()
        {
            return courceGateway.GetAllSemister();
        }

        public List<SelectListItem> GetAllSemisterForDropdown()
        {
            List<Semister> semisters= GetAllSemister();
            List<SelectListItem> selectListItems = new List<SelectListItem>()
            {
                new SelectListItem()
                {
                    Text = "--Select--",
                    Value = ""
                }
            };
            foreach (Semister semister in semisters)
            {
                SelectListItem selectListItem = new SelectListItem();
                selectListItem.Text = semister.Name;
                selectListItem.Value = semister.Id.ToString();
                selectListItems.Add(selectListItem);
            }
            return selectListItems;
        }
    }
}