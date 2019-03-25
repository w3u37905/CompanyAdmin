using CompanyAdmin.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Unity;

namespace CompanyAdmin.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {

        [Dependency]
        public MyDBContext DbContext { get; set; }

        public IEnumerable<Department> GetAll()
        {
            return DbContext.Departments.ToList();
        }

        public Department GetById(object id)
        {
            return DbContext.Departments.Find(id);
        }

        public void Insert(Department obj)
        {
            DbContext.Departments.Add(obj);
        }

        public void Update(Department obj)
        {
            DbContext.Departments.Attach(obj);
            DbContext.Entry(obj).State = EntityState.Modified;
        }

        public void Delete(object id)
        {
            Department existing = DbContext.Departments.Find(id);
            DbContext.Departments.Remove(existing);
        }

        public void Save()
        {
            DbContext.SaveChanges();
        }

    }
}