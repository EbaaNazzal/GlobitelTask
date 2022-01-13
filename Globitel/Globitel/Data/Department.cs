using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Globitel.Data
{
    [Table("Departments")]
    public class Department
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "TxtValidate")]
        public string Name { get; set; }
        public List<Employee> Employees { get; set; }
    }
}
