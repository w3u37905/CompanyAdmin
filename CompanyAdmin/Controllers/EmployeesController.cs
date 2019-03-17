using CompanyAdmin.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CompanyAdmin.Controllers
{
    public class EmployeesController : Controller
    {

        private MyDBContext _context;

        public EmployeesController()
        {
            _context = new MyDBContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ViewResult Index()
        {
            var employees = _context.Employees.Include(c => c.Department).ToList();

            return View(employees);
        }

        //private IEnumerable<Employee> GetEmployees()
        //{
        //    return new List<Employee>
        //    {
        //        new Employee
        //        {
        //            FirstName = "Menelaos",
        //            LastName = "Giannopoulos",
        //            EmailAddress = "megianno@gmail.com",
        //            Birthdate = "19/05/1987"
        //        }
        //    };
        //}

    }
}