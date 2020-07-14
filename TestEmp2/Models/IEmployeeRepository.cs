using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestEmp2.Models
{
    public interface IEmployeeRepository
    {
        public IEnumerable<Employee> Gets();
        Employee Create(Employee employee);
        Employee Edit(Employee employee);
        bool Delete(int id);
        Employee Get(int id);
    }
}
