using CompanyAdmin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CompanyAdmin.Controllers
{
    public class EmployeesController : Controller
    {
        // GET: Employees
        public ViewResult Index()
        {
            var employees = GetEmployees();

            return View(employees);
        }

        private IEnumerable<Employee> GetEmployees()
        {
            return new List<Employee>
            {
                new Employee
                {
                    FirstName = "Menelaos",
                    LastName = "Giannopoulos",
                    EmailAddress = "megianno@gmail.com",
                    Birthdate = "19/05/1987",
                    Department = "Software"
                }
            };
        }

    }
}