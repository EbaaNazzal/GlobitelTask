using Globitel.Data;
using Globitel.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Globitel.Services
{
    public class AccountService: IAccountService
    {
        UserManager<AppUser> userManager;
        SignInManager<AppUser> signInManager;

        public AccountService(UserManager<AppUser> _userManager, SignInManager<AppUser> _signInManager)
        {
            userManager = _userManager;
            signInManager = _signInManager;
        }

        public async Task<IdentityResult> Create(SignUpModel signup)
        {
            AppUser user = new AppUser();
            user.Name = signup.Name;
            user.Email = signup.Email;
            user.UserName = signup.Email;

            var result = await userManager.CreateAsync(user, signup.Password);
            return result;
        }
        public async Task<SignInResult> SignIn(LoginModel loginModel)
        {
            var result = await signInManager.PasswordSignInAsync(loginModel.Email, loginModel.Password, loginModel.RememberMe, false);
            return result;
        }

        public async Task Signout()
        {
            await signInManager.SignOutAsync();
        }
    }
}
