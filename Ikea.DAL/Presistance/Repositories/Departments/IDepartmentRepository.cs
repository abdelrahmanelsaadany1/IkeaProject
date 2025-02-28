using Ikea.DAL.Models.Departments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ikea.DAL.Presistance.Repositories.Departments
{
    public interface IDepartmentRepository
    {
        IEnumerable<Department> GetAll(bool WithAsNoTracking = true);
        IQueryable<Department> GetAllQueryable();
        Department? GetById(int id);
        int Add(Department entity);
        int Update(Department entity);
        int Delete(Department entity);
    }
}
