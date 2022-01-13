using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Globitel.Models
{
    public class SignUpModel
    {
        [Required(ErrorMessage = "TxtValidate")]
        public string Name { get; set; }
        [Required(ErrorMessage = "TxtValidate")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "TxtValidate")]
        [DataType(DataType.Password)]
        [Compare("ConfirmPassword")]
        public string Password { get; set; }
        [Required(ErrorMessage = "TxtValidate")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
