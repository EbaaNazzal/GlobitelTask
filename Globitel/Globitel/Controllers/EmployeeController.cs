using ClosedXML.Excel;
using Globitel.Data;
using Globitel.Models;
using Globitel.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Globitel.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        IDepartmentService departmentService;
        IEmployeeService employeeService;
        IConfiguration configuration;

        public EmployeeController(IDepartmentService _departmentService, IEmployeeService _employeeService, IConfiguration _configuration)
        {
            departmentService = _departmentService;
            employeeService = _employeeService;
            configuration = _configuration;
        }

        public IActionResult NewEmployee()
        {

            ViewData["flag"] = 1;
            VmEmployee vmEmployee = new VmEmployee();
            vmEmployee.employee = new Employee();
            vmEmployee.departments = departmentService.GetAllDepartment();
            return View(vmEmployee);
        }

        public IActionResult Create(VmEmployee vmEmployee)
        {
            ViewData["flag"] = 1;
            string filePath = Path.Combine(Directory.GetCurrentDirectory(),  configuration["FilePath"], vmEmployee.EmployeePhoto.FileName);
            vmEmployee.EmployeePhoto.CopyTo(new FileStream(filePath, FileMode.Create));

            vmEmployee.employee.Photo = "http://localhost/Globitel/Images/" + vmEmployee.EmployeePhoto.FileName;
            vmEmployee.departments = departmentService.GetAllDepartment();
            if (ModelState.IsValid == true)
            {
                employeeService.Insert(vmEmployee.employee);
                vmEmployee.employee = new Employee();
            }
            return View("NewEmployee", vmEmployee);
        }

        public IActionResult EmployeeList(int pg = 1)
        {
            VmEmployee vmEmployee = new VmEmployee();
            List<Employee> liEmployee = employeeService.GetAllEmployee();
            const int pageSize = 10;
            if (pg < 1)
                pg = 1;
            int recsCount = liEmployee.Count();
            var pager = new Pager(recsCount, pg, pageSize);
            int recSkip = (pg - 1) * pageSize;
            vmEmployee.employees = liEmployee.Skip(recSkip).Take(pager.PageSize).ToList();
            this.ViewBag.Pager = pager;

            return View(vmEmployee);
        }

        public IActionResult Search()
        {
            string name = Request.Form["txtName"];
            List<Employee> liEmployee = employeeService.GetEmployeeByName(name);
            return View("EmployeeList", liEmployee);
        }

        public IActionResult Delete(int id)
        {
            VmEmployee vmEmployee = new VmEmployee();

            employeeService.Delete(id);
            vmEmployee.employees = employeeService.GetAllEmployee();
            return View("EmployeeList", vmEmployee);
        }

        public IActionResult Edit(int id)
        {
            VmEmployee vmEmployee = new VmEmployee();
            ViewData["flag"] = 0;
            vmEmployee.employee = employeeService.GetEmployeeById(id);
            vmEmployee.departments = departmentService.GetAllDepartment();
            return View("NewEmployee", vmEmployee);
        }
        public IActionResult Update(Employee employee)
        {
            ViewData["flag"] = 0;
            employeeService.Update(employee);
            VmEmployee vmEmployee = new VmEmployee();
            vmEmployee.departments = departmentService.GetAllDepartment();
            return View("NewEmployee", vmEmployee);
        }
        public IActionResult ExportToExcel()
        {
            using (var workbook = new XLWorkbook())
            {
                List <Employee> employees= employeeService.GetActiveEmployees();
                var worksheet = workbook.Worksheets.Add("Active Employees");
                var currentRow = 1;
                worksheet.Cell(currentRow, 1).Value = "Name";
                worksheet.Cell(currentRow, 2).Value = "Birthdate";
                worksheet.Cell(currentRow, 3).Value = "Joining date";
                worksheet.Cell(currentRow, 4).Value = "Gender";
                worksheet.Cell(currentRow, 5).Value = "Department";

                foreach (var item in employees)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = item.FirstName + " " + item.LastName;
                    worksheet.Cell(currentRow, 2).Value = item.DateOfBirth;
                    worksheet.Cell(currentRow, 3).Value = item.DateOfJoining;
                    worksheet.Cell(currentRow, 4).Value = item.department.Name;

                }

                using (var stream = new MemoryStream()) 
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spredsheetml.sheet","EmployeeInfo.xlsx");
                }
            }
        }
    }
}
