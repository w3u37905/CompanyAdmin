using CompanyAdmin.Models;
using CompanyAdmin.ViewModels;
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

        public ActionResult New()
        {
            var departments = _context.Departments.ToList();

            var viewModel = new EmployeeFormViewModel
            {
                Departments = departments
            };

            return PartialView("EmployeeForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var employee = _context.Employees.SingleOrDefault(c => c.Id == id);

            if (employee == null)
                return HttpNotFound();

            var viewModel = new EmployeeFormViewModel
            {
                Employee = employee,
                Departments = _context.Departments.ToList()
            };

            return PartialView("EmployeeForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Employee employee)
        {
            if (employee.Id == 0)
            {
                _context.Employees.Add(employee);
            }
            else
            {
                var employeeInDb = _context.Employees.Single(m => m.Id == employee.Id);
                employeeInDb.FirstName = employee.FirstName;
                employeeInDb.LastName = employee.LastName;
                employeeInDb.EmailAddress = employee.EmailAddress;
                employeeInDb.Birthdate = employee.Birthdate;
                employeeInDb.DepartmentId = employee.DepartmentId;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Employees");
        }

        [HttpPost]
        public void Delete(int id)
        {
            var employee = _context.Employees.SingleOrDefault(c => c.Id == id);

            if (employee == null)
                return;

            _context.Employees.Remove(employee);
            _context.SaveChanges();
        }


    }
}