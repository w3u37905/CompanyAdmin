using CompanyAdmin.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Unity;

namespace CompanyAdmin.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {

        [Dependency]
        public MyDBContext DbContext { get; set; }

        public IEnumerable<Employee> GetAll()
        {
            return DbContext.Employees.Include(c => c.Department).ToList();
        }

        public Employee GetById(object id)
        {
            return DbContext.Employees.Find(id);
        }

        public void Insert(Employee obj)
        {
            DbContext.Employees.Add(obj);
        }

        public void Update(Employee obj)
        {
            DbContext.Employees.Attach(obj);
            DbContext.Entry(obj).State = EntityState.Modified;
        }

        public void Delete(object id)
        {
            Employee existing = DbContext.Employees.Find(id);
            DbContext.Employees.Remove(existing);
        }

        public void Save()
        {
            DbContext.SaveChanges();
        }

    }
}