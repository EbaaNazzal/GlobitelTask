using Globitel.Data;
using Globitel.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Globitel.Controllers
{
    [Authorize]
    public class DepartmentController : Controller
    {
        IDepartmentService departmentService;

        public DepartmentController(IDepartmentService _departmentService)
        {
            departmentService = _departmentService;
        }

        public IActionResult NewDepartment()
        {
            return View();
        }

        public IActionResult SaveData(Department department)
        {
            departmentService.Insert(department);
            return View("NewDepartment");
        }

        public IActionResult DepartmentList()
        {
            List<Department> liDepartment = departmentService.GetAllDepartment();
            return View(liDepartment);
        }
    }
}
