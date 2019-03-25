using CompanyAdmin.Models;
using CompanyAdmin.Repositories;
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

        private IDepartmentRepository departmentRepository;
        private IEmployeeRepository employeeRepository;


        public EmployeesController(IDepartmentRepository departmentRepository,
            IEmployeeRepository employeeRepository)
        {
            this.departmentRepository = departmentRepository;
            this.employeeRepository = employeeRepository;
        }


        public ViewResult Index()
        {
            var employees = employeeRepository.GetAll();

            return View(employees);
        }

        public ActionResult New()
        {
            var departments = departmentRepository.GetAll();

            var viewModel = new EmployeeFormViewModel
            {
                Employee = new Employee(),
                Departments = departments
            };

            return PartialView("EmployeeForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var employee = employeeRepository.GetById(id);

            if (employee == null)
                return HttpNotFound();

            var viewModel = new EmployeeFormViewModel
            {
                Employee = employee,
                Departments = departmentRepository.GetAll()
            };

            return PartialView("EmployeeForm", viewModel);
        }

        private bool IsDepartmentFull(int departmentId)
        {
            var departmentEmployeesNumber = employeeRepository.GetAll().Count(x => x.DepartmentId == departmentId);
            var department = departmentRepository.GetById(departmentId);

            if (department.MaxEmployees == departmentEmployeesNumber)
            {
                return true;
            }
            return false;
        }

        public ActionResult Save(Employee employee)
        {

            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index", "Employees");
            }


            if (employee.Id == 0)
            {
                if (IsDepartmentFull(employee.DepartmentId))
                {
                    // employee can not be assigned to department
                    return RedirectToAction("Index", "Employees");
                }

                employeeRepository.Insert(employee);
            }
            else
            {
                var employeeInDb = employeeRepository.GetById(employee.Id);
                employeeInDb.FirstName = employee.FirstName;
                employeeInDb.LastName = employee.LastName;
                employeeInDb.EmailAddress = employee.EmailAddress;
                employeeInDb.Birthdate = employee.Birthdate;
                employeeInDb.DepartmentId = employee.DepartmentId;
            }

            employeeRepository.Save();

            return RedirectToAction("Index", "Employees");
        }

        public void Delete(int id)
        {
            var employee = employeeRepository.GetById(id);

            if (employee == null)
                return;

            employeeRepository.Delete(id);
            employeeRepository.Save();
        }


    }
}