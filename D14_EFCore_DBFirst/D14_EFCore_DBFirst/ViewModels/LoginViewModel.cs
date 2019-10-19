using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace D14_EFCore_DBFirst.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [MaxLength(20)]
        public string MaKh { get; set; }
        [Required]
        [MaxLength(20)]
        [DataType(DataType.Password)]
        public string MatKhau { get; set; }
    }
}
