using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ikea.BLL.Models.Departments
{
    public class CreatedDepartmentDto
    {
        [Required(ErrorMessage ="Code is Requored !!!")]
        public string Code { get; set; } = null!;
        [Required(ErrorMessage = "Name is Requored !!!")]
        public string Name { get; set; } = null!;
        
        public string? Description { get; set; }
        [Display(Name = "Date Of Creation")]
        public DateOnly CreationDate { get; set; }
    }
}
