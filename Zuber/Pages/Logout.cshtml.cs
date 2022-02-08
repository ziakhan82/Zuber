using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Zuber.Services.EFServices;

namespace Zuber.Pages
{
    public class LogoutModel : PageModel
    {
        public SingletonUser User;
        public LogoutModel( SingletonUser s)
        { 
            User = s;
        }
        public IActionResult OnGet()
        {
            User.Logout();
            return RedirectToPage("Login");
        }
    }
}
