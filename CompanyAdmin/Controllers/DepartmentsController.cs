using CompanyAdmin.Models;
using CompanyAdmin.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CompanyAdmin.Controllers
{
    public class DepartmentsController : Controller
    {

        private IDepartmentRepository departmentRepository;
        private IEmployeeRepository employeeRepository;



        public DepartmentsController(IDepartmentRepository departmentRepository,
            IEmployeeRepository employeeRepository)
        {
            this.departmentRepository = departmentRepository;
            this.employeeRepository = employeeRepository;
        }    


        public ViewResult Index()
        {
            var departments = departmentRepository.GetAll();

            return View(departments);
        }


        public ActionResult Edit(int id)
        {
            var department = departmentRepository.GetById(id);

            if (department == null)
                return HttpNotFound();

            return PartialView("DepartmentForm", department);
        }

        public ActionResult New()
        {
            var department = new Department();

            return PartialView("DepartmentForm", department);
        }

        public ActionResult Save(Department department)
        {

            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index", "Departments");
            }

            if (department.Id == 0)
            {
                departmentRepository.Insert(department);
            }                
            else
            {
                var departmentEmployeesNumber = employeeRepository.GetAll().Count(x => x.DepartmentId == department.Id);
                //max-employees value cannot be lower than current number of assigned employees
                if (departmentEmployeesNumber > department.MaxEmployees)
                {
                    return RedirectToAction("Index", "Departments");
                }

                var departmentInDb = departmentRepository.GetById(department.Id);
                departmentInDb.Name = department.Name;
                departmentInDb.MaxEmployees = department.MaxEmployees;
            }

            departmentRepository.Save();

            return RedirectToAction("Index", "Departments");
        }

        public JsonResult Delete(int id)
        {
            bool result = false;
            var department = departmentRepository.GetById(id);
                       

            if (department != null)
            {
                bool existsAssignedEmployees = employeeRepository.GetAll().Any(x => x.DepartmentId == id);

                // a department can only be deleted when there are no employees assigned to it.
                if (!existsAssignedEmployees)
                {
                    departmentRepository.Delete(id);
                    departmentRepository.Save();
                    result = true; 
                }
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

    }
}