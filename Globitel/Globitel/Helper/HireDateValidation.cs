using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Globitel.Helper
{
    public class HireDateValidation:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (Convert.ToDateTime(value) <= DateTime.Now)
                return ValidationResult.Success;
            else
            {
                return new ValidationResult("Hiredate should less than today's date");
            }
        }
    }
}
