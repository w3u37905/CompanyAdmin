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
        // GET: Departments
        public ActionResult Random()
        {
            var department = new Department() { Name = "Software", MaxEmployees = 20 };

            return View(department);
        }

        public ViewResult Index()
        {
            var departments = GetDepartments();

            return View(departments);
        }

        //public ActionResult Details(int id)
        //{
        //    var customer = GetDepartments().SingleOrDefault(c => c.Id == id);

        //    if (customer == null)
        //        return HttpNotFound();

        //    return View(customer);
        //}

        private IEnumerable<Department> GetDepartments()
        {
            return new List<Department>
            {
                new Department { Name = "Software", MaxEmployees = 20 },
                new Department { Name = "Hardware", MaxEmployees = 10 }
            };
        }



    }
}