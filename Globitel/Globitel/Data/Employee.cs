using Globitel.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Globitel.Data
{
    [Table("Employees")]
    public class Employee
    {
        public int Id { set; get; }
        [Required(ErrorMessage = "TxtValidate")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "TxtValidate")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "TxtValidate")]
        [RegularExpression(@"07(7|8|9)\d{7}", ErrorMessage = "For Example 07*1234567 ")]
        public string Phone { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "SelectValidate")]
        public string Gender { get; set; }
        [HireDateValidation]
        public DateTime? DateOfBirth { get; set; }
        [HireDateValidation]
        public DateTime? DateOfJoining { get; set; }
        public string Photo { get; set; }
        [Required(ErrorMessage = "SelectValidate")]
        public string Status { get; set; }
        [Required(ErrorMessage = "SelectValidate")]
        [ForeignKey("department")]
        public int DepartmentId { get; set; }
        public Department department { get; set; }
    }
}
