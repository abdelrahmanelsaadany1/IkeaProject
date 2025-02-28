using Ikea.BLL.Models.Departments;
using Ikea.DAL.Models.Departments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ikea.BLL.Services.Departments
{
    public interface IDepartmentService
    {
        IEnumerable<DepartmentToReturnDto> GetALLDepartments();
        DepartmentsDetailsReturnDto? GetDepartmentById(int id);
        int CreateDepartment(CreatedDepartmentDto departmentDto);
        int UpdateDepartment(UpdateDepartmentDto departmentDto);
        int DeleteDepartment(int id);

    }
}
