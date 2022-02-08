using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Zuber.Models;
using Zuber.Services.EFServices;
using Zuber.Services.Interfaces;

namespace Zuber.Pages
{
    public class GetProfileModel : PageModel
    {
        public IUserService service;
        public SingletonUser User;
        [BindProperty]
        public ZuberUser GetUser { get; set; }
        public GetProfileModel(SingletonUser s,IUserService i)
        {
            User = s;
            service = i;
            
        }
        public IActionResult OnGet(int id)
        {
            if (User.SignedIn)
            {
                GetUser = service.GetZuberUserById(id);
                return Page();
            }
            else
            {
                return RedirectToPage("Login");
            }
        }
    }
}
