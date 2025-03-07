using Ikea.BLL.Models.Departments;
using Ikea.BLL.Services.Departments;
using Ikea.DAL.Presistance.Repositories.Departments;
using Microsoft.AspNetCore.Mvc;
using Ikea.PL.Models.Departments;

namespace Ikea.PL.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService departmentService;
        private readonly ILogger<DepartmentController> _logger;
        private readonly IWebHostEnvironment _webHostEnvironment;

        #region Services
        public DepartmentController(IDepartmentService _departmentService, ILogger<DepartmentController> logger, IWebHostEnvironment webHostEnvironment)
        {
            departmentService = _departmentService;
            _logger = logger;
            _webHostEnvironment = webHostEnvironment;
        }
        #endregion
        #region Index
        [HttpGet]
        public IActionResult Index()
        {
            var departments = departmentService.GetALLDepartments();
            return View(departments);
        }

        #endregion
        #region Create
        #region Get
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        #endregion
        #region Post
        [HttpPost]
        public IActionResult Create(CreatedDepartmentDto department)
        {
            if (!ModelState.IsValid)

                return View(department);
            var Message = string.Empty;
            try
            {
                var Result = departmentService.CreateDepartment(department);
                if (Result > 0)

                    return RedirectToAction(nameof(Index));

                else
                {
                    Message = "Deparatment hasn't been created";
                    ModelState.AddModelError("", Message);
                    return View(department);
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                if (_webHostEnvironment.IsDevelopment())
                {
                    Message = ex.Message;
                    return View(department);
                }
                else
                {
                    Message = "Deparatment hasn't been created";

                    return View("Error", Message);

                }

            }





        }
        #endregion
        #endregion
        #region Details
        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id is null)
            {
                return BadRequest();
            }
            var department = departmentService.GetDepartmentById(id.Value);
            if (department is null)
            {
                return NotFound();
            }
            return View(department);

        }
        #endregion
        #region Edit
        #region Get
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id is null)
            {
                return BadRequest();
            }
            var department = departmentService.GetDepartmentById(id.Value);
            if (department is null)
            {
                return NotFound();
            }
            return View(new DepartmentEditViewModel()
            {

                Code = department.Code,
                Name = department.Name,
                Description = department.Description,
                CreationDate = department.CreationDate
            });




        } 
               
        

    #endregion
        #region Post
    [HttpPost]
        public IActionResult Edit([FromRoute] int id, DepartmentEditViewModel departmentVM)
        {
            if (!ModelState.IsValid)
                return View(departmentVM);
            var Message = string.Empty;
            try
            {
                var UpdateDepartment = new UpdateDepartmentDto()
                {
                    Id = id,
                    Code = departmentVM.Code,
                    Name = departmentVM.Name,
                    Description = departmentVM.Description,
                    CreationDate = departmentVM.CreationDate
                };
                var Updated = departmentService.UpdateDepartment(UpdateDepartment)>0;
                if (Updated)
                    return RedirectToAction(nameof(Index));
                else
                {
                    Message = "Deparatment hasn't been updated";
                   
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                Message =_webHostEnvironment.IsDevelopment()?ex.Message: "Deparatment hasn't been updated";

            

            }
            ModelState.AddModelError("", Message);
            return View(departmentVM);
        }






        #endregion
        #endregion
        #region Delete
        #region Get
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id is null)
            {
                return BadRequest();
            }
            var department = departmentService.GetDepartmentById(id.Value);
            if (department is null)
            {
                return NotFound();
            }
            return View(department);
        }

        #endregion
        #region Post

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var Message = string.Empty;
            try
            {
                var Deleted = departmentService.DeleteDepartment(id) > 0;
                if (Deleted)
                    return RedirectToAction(nameof(Index));
                else
                {
                    Message = "Deparatment hasn't been deleted";
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                Message = _webHostEnvironment.IsDevelopment() ? ex.Message : "Deparatment hasn't been deleted";
            }
            return RedirectToAction(nameof(Index));



        }

        #endregion
        #endregion

    }
}
