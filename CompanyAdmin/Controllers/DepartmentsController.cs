using CompanyAdmin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CompanyAdmin.Controllers
{
    public class DepartmentsController : Controller
    {

        private MyDBContext _context;

        public DepartmentsController()
        {
            _context = new MyDBContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ViewResult Index()
        {
            var departments = _context.Departments.ToList();

            return View(departments);
        }

        //private IEnumerable<Department> GetDepartments()
        //{
        //    return new List<Department>
        //    {
        //        new Department { Id = 1, Name = "Software", MaxEmployees = 20 },
        //        new Department { Id = 2, Name = "Hardware", MaxEmployees = 10 }
        //    };
        //}

    }
}