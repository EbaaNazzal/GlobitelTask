using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Globitel.Data
{
    public class AppUser:IdentityUser
    {
        [Required(ErrorMessage = "TxtValidate")]
        public string Name { get; set; }
    }
}
