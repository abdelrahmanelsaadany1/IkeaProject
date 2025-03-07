using Ikea.BLL.Models.Departments;
using Ikea.DAL.Presistance.Repositories.Departments;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ikea.BLL.Services.Departments
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepositoryRebo;

        public DepartmentService(IDepartmentRepository departmentRepositoryRebo)
        {
              _departmentRepositoryRebo = departmentRepositoryRebo;
        }
        public IEnumerable<DepartmentToReturnDto> GetALLDepartments()
        {
            var departments = _departmentRepositoryRebo.GetAllQueryable()
                .Select(D => new DepartmentToReturnDto()
                {
                    Id = D.Id,
                    Code = D.Code,
                   
                    Name = D.Name,
                    CreationDate = D.CreationDate
                }).AsNoTracking().ToList();
            return departments;


        }
        public DepartmentsDetailsReturnDto? GetDepartmentById(int id)
        {

            var department = _departmentRepositoryRebo.GetById(id);
            if (department is not null)
            {
                return new DepartmentsDetailsReturnDto()
                {
                    Id = department.Id,
                    Code = department.Code,
                    Description = department.Description,
                    Name = department.Name,
                    CreationDate = department.CreationDate,
                    CreatedBy = department.CreatedBy,
                    CreatedOn = department.CreatedOn,
                    LastModificationBy = department.LastModificationBy,
                    LastModificationOn = department.LastModificationOn,
                    IsDeleted = department.IsDeleted



                };
               
            }
            return null;




        }

        public int CreateDepartment(CreatedDepartmentDto departmentDto)
        {

            var CreatedDepartment = new DAL.Models.Departments.Department()
            {
                Name = departmentDto.Name,
                Code = departmentDto.Code,
                Description = departmentDto.Description,
                CreationDate = departmentDto.CreationDate,
                CreatedBy = 1,
                LastModificationBy = 1,
                LastModificationOn = DateTime.UtcNow,
             

            };
            return _departmentRepositoryRebo.Add(CreatedDepartment);

        }
        public int UpdateDepartment(UpdateDepartmentDto departmentDto)
        {

            var UpdatedDepartment = new DAL.Models.Departments.Department()
            {
                Id = departmentDto.Id,
                Name = departmentDto.Name,
                Code = departmentDto.Code,
                Description = departmentDto.Description,
                CreationDate = departmentDto.CreationDate,
                CreatedBy = 1,
                LastModificationBy = 1,
                LastModificationOn = DateTime.UtcNow,
            };
            return _departmentRepositoryRebo.Update(UpdatedDepartment);
        }
        public int DeleteDepartment(int id)
        {
            var department = _departmentRepositoryRebo.GetById(id);
            if (department is not null)
            {
                return _departmentRepositoryRebo.Delete(department);
            }
            return 0;
        }
    }
}
