using Globitel.Models;
using Globitel.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Globitel.Controllers
{
    public class AccountController : Controller
    {
        private readonly IStringLocalizer<EmployeeController> _localizer;

        IAccountService accountService;
        SignUpModel signupModel;

        public AccountController(IAccountService _accountService , IStringLocalizer<EmployeeController> localizer)
        {
            accountService = _accountService;
            signupModel = new SignUpModel();
            _localizer = localizer;
        }

        public IActionResult Signup()
        {
            return View();
        }

        public async Task<IActionResult> CreateAccount(SignUpModel signUpModel)
        {
            var result = await accountService.Create(signUpModel);
            return View("Signup");
        }

        public IActionResult SignIn()
        {
            return View();
        }

        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            var result = await accountService.SignIn(loginModel);
            if (result.Succeeded)
            {
                return RedirectToAction("EmployeeList", "Employee");
            }
            else
            {
                ViewData["errorMessage"] =_localizer["loginFailedMsg"];
                return View("SignIn");
            }
        }

        public async Task<IActionResult> Logout()
        {
            await accountService.Signout();
            return View("SignIn");
        }
    }
}
