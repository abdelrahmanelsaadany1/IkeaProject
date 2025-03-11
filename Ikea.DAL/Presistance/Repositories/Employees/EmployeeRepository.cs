using Ikea.DAL.Models.Departments;
using Ikea.DAL.Models.Employees;
using Ikea.DAL.Presistance.Data;
using Ikea.DAL.Presistance.Repositories._Generic;
using Ikea.DAL.Presistance.Repositories.Departments;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ikea.DAL.Presistance.Repositories.Employees
{
    internal class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

    }
}
