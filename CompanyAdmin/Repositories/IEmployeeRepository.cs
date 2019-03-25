using CompanyAdmin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyAdmin.Repositories
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAll();
        Employee GetById(object id);
        void Insert(Employee obj);
        void Update(Employee obj);
        void Delete(object id);
        void Save();
    }
}
