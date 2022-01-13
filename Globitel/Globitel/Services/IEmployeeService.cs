using Globitel.Data;
using System.Collections.Generic;

namespace Globitel.Services
{
    public interface IEmployeeService
    {
        List<Employee> GetAllEmployee();
        List<Employee> GetEmployeeByName(string fname);
        Employee GetEmployeeById(int id);
        void Update(Employee employee);
        void Insert(Employee employee);
        void Delete(int id);
        List<Employee> GetActiveEmployees();

    }
}