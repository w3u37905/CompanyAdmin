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


        public ActionResult Edit(int id)
        {
            var department = _context.Departments.SingleOrDefault(c => c.Id == id);

            if (department == null)
                return HttpNotFound();

            return View("DepartmentForm", department);
        }

        public ActionResult New()
        {
            var department = new Department();

            return View("DepartmentForm", department);
        }

        [HttpPost]
        public ActionResult Save(Department department)
        {
            if (department.Id == 0)
                _context.Departments.Add(department);
            else
            {
                var departmentInDb = _context.Departments.Single(c => c.Id == department.Id);
                departmentInDb.Name = department.Name;
                departmentInDb.MaxEmployees = department.MaxEmployees;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Departments");
        }

        [HttpPost]    
        public void Delete(int id)
        {
            var department = _context.Departments.SingleOrDefault(c => c.Id == id);

            if (department == null)
                return;

            _context.Departments.Remove(department);
            _context.SaveChanges();

        }

    }
}