using Globitel.Data;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Globitel.Models
{
    public class VmEmployee
    {
        public List<Department> departments { get; set; }
        public List<Employee> employees { get; set; }
        public Employee employee { get; set; }
        public IFormFile EmployeePhoto { get; set; }
    }
}
