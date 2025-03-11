using Ikea.DAL.Models.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ikea.DAL.Models;
using Ikea.DAL.Models.Departments;
using Ikea.DAL.Presistance.Repositories._Generic;

namespace Ikea.DAL.Presistance.Repositories.Employees
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
     

    }
}
