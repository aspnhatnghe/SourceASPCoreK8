using System;
using System.ComponentModel.DataAnnotations;

namespace D06_Validation.Models
{
    public class BirthDateCheckAttribute : ValidationAttribute
    {
        public BirthDateCheckAttribute(string errorMessage = "Ngày sinh không hợp lệ") : base(errorMessage)
        {
        }

        public override bool IsValid(object value)
        {
            var birthDate = (DateTime) value;
            //kiểm tar đăng ký từ 5tuoi trở lên
            return birthDate.AddYears(5) < DateTime.Now;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var model = validationContext.ObjectInstance as Employee;
            if (model == null)
            {
                throw new ArgumentException("Tham số truyền không đúng");
            }
            if (DateTime.Now.Year - model.BirthDate.Year < 5)
            {
                return new ValidationResult("Chưa đủ 5 tuổi");
            }

            return ValidationResult.Success;
        }
    }
}