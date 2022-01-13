using Globitel.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Globitel.Services
{
    public class DepartmentService: IDepartmentService
    {
        GlobitelDbContext context;
        public DepartmentService(GlobitelDbContext _context)
        {
            context = _context;
        }

        public List<Department> GetAllDepartment()
        {
            List<Department> liDepartment = context.Departments.ToList();
            return liDepartment;
        }

        public void Insert(Department department)
        {
            context.Departments.Add(department);
            context.SaveChanges();
        }
    }
}
