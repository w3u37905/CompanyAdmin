using CompanyAdmin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyAdmin.Repositories
{
    public interface IDepartmentRepository
    {
        IEnumerable<Department> GetAll();
        Department GetById(object id);
        void Insert(Department obj);
        void Update(Department obj);
        void Delete(object id);
        void Save();
    }
}
