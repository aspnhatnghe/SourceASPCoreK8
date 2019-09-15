using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace D06_Validation.Models
{
    public class Employee : EmployeeInfo
    {
        public int Id { get; set; }

        [Display(Name ="Mã nhân viên")]
        [StringLength(5)]
        [Remote(action:"CheckUserName", controller:"Demo", ErrorMessage ="Mã này đã được đăng ký")]
        public string MaNv { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }  
        
        [DataType(DataType.Url)]
        public string Website { get; set; }

        [Display(Name ="Ngày sinh")]
        [DataType(DataType.Date)]
        [BirthDateCheck]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Giới tính")]
        public string Gender { get; set; }

        [Display(Name = "Lương")]
        [Range(0, double.MaxValue)]
        public double Salary { get; set; }

        [Display(Name ="Làm bán thời gian")]
        public bool IsPartTime { get; set; }

        [Display(Name ="Địa chỉ")]
        public string Address { get; set; }

        [Display(Name = "Điện thoại")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [Display(Name ="Số tài khoản")]
        [CreditCard]
        //[DataType(DataType.CreditCard)]
        public string CreditCard { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Thông tin thêm")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
    }
}
