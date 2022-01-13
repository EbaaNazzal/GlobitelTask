using Globitel.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Globitel.Services
{
    public class EmployeeService : IEmployeeService
    {
        GlobitelDbContext context;
        public EmployeeService(GlobitelDbContext _context)
        {
            context = _context;
        }

        public List<Employee> GetAllEmployee()
        {
            List<Employee> liEmployee = context.Employees.Include("department").ToList();
            return liEmployee;
        }

        public List<Employee> GetEmployeeByName(string fname)
        {
            List<Employee> liEmployee = context.Employees.Where(e => e.FirstName == fname).Include("department").ToList();
            return liEmployee;
        }

        public Employee GetEmployeeById(int id)
        {
            Employee employee = context.Employees.Find(id);
            return employee;
        }

        public void Insert(Employee employee)
        {
            context.Employees.Add(employee);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            Employee employee = context.Employees.Find(id);
            context.Employees.Remove(employee);
            context.SaveChanges();
        }

        public void Update(Employee employee)
        {
            context.Employees.Attach(employee);
            context.Entry(employee).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }

        public List<Employee> GetActiveEmployees() 
        {
            List<Employee> liEmployee = context.Employees.Where(e => e.Status == "Active").Include("department").ToList();
            return liEmployee;
        }
    }
}
