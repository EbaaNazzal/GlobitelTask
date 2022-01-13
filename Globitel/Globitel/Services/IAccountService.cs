using Globitel.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Globitel.Services
{
    public interface IAccountService
    {
        Task<IdentityResult> Create(SignUpModel signup);
        Task<SignInResult> SignIn(LoginModel loginModel);
        Task Signout();
    }
}