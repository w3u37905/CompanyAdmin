using CompanyAdmin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompanyAdmin.ViewModels
{
    public class EmployeeFormViewModel
    {
        public IEnumerable<Department> Departments { get; set; }
        public Employee Employee { get; set; }
        public string Title
        {
            get
            {
                if (Employee != null && Employee.Id != 0)
                    return "Edit Employee";

                return "New Employee";
            }
        }

    }
}