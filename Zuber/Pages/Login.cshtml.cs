using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Zuber.Models;
using Zuber.Services.EFServices;
using Zuber.Services.Interfaces;

namespace Zuber.Pages
{
    public class LoginModel : PageModel
    {
        IUserService service;
        public SingletonUser User;
        [BindProperty]
        public ZuberUser input { get; set; }
        [BindProperty]
        public bool failedLogin { get; set; }
        public LoginModel(IUserService s, SingletonUser su)
        {
            service = s;
            User = su;
        }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            ZuberUser user = service.GetZuberUser(input.Email);
            if (user != null && EFUserService.CheckHashedPassword(user.Email, user.Password, input.Password))
            {
                User.Login(user);
                //IdentityService.Identity.Login(user);
                return RedirectToPage("Index");
            }
            failedLogin = true;
            return Page();
        }
    }
}
