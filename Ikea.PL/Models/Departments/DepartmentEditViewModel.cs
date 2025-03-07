using System.ComponentModel.DataAnnotations;

namespace Ikea.PL.Models.Departments
{
    public class DepartmentEditViewModel
    {
        [Required(ErrorMessage ="Code is required !!")]
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        
        public string? Description { get; set; }
        public DateOnly CreationDate { get; set; }
    }
}
