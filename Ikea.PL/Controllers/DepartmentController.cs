using Ikea.BLL.Services.Departments;
using Ikea.DAL.Presistance.Repositories.Departments;
using Microsoft.AspNetCore.Mvc;

namespace Ikea.PL.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService departmentService;

        public DepartmentController(IDepartmentService _departmentService)
        {
            _departmentService = departmentService;
        }
        [HttpGet]
        public IActionResult Index()
        {
           var departments = departmentService.GetALLDepartments();
            return View(departments);
        }
    }
}
