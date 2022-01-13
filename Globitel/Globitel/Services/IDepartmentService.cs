using Globitel.Data;
using System.Collections.Generic;

namespace Globitel.Services
{
    public interface IDepartmentService
    {
        void Insert(Department department);
        List<Department> GetAllDepartment();
    }
}