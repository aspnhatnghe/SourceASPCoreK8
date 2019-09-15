using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace D06_Validation.Models
{
    public class EmployeeInfo
    {
        [Display(Name ="Họ tên")]
        [Required(ErrorMessage ="*")]
        [StringLength(50, MinimumLength =5, ErrorMessage ="Từ 5 đến 50")]
        public string FullName { get; set; }
        [Display(Name ="Tuổi")]
        [Required(ErrorMessage ="*")]
        [Range(15, 55, ErrorMessage ="Tuổi từ 15 đến 55")]
        public int Age { get; set; }
    }
}
