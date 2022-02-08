using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Zuber.Models;
using Zuber.Services.EFServices;
using Zuber.Services.Interfaces;
using Zuber.CustomAtributes;

namespace Zuber.Pages
{
    public class RegisterModel : PageModel
    {
        public class InputModel
        {
            [Required]
            [RegularExpression(@"^[A-Za-z]+\s?[A-Za-z]*$",ErrorMessage ="Please, insert your name using only letters")]
            public string Name { get; set; }
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            [RegularExpression(@"^([\w\.\-]+)@([\w\-\.]+)((\.(\w){2,3})+)$", ErrorMessage = "Please, enter valid email adress")]
            //[RegularExpression(@"^[A-Z0-9a-z._%+-]+@[A-Z0-9a-z.-]+\.[A-Za-z]{2,}$.", ErrorMessage = "Please, enter valid email adress")]
            //[RegularExpression(@"^[A-Z0-9a-z._%+-]+@edu\.easj\.dk"),ErrorMessage ="Please, enter your Zealand email adress"] version for zealand students mails
            //[RegularExpression(@"^[a-z]{4}[0-9]{4}@edu\.easj\.dk"),ErrorMessage ="Please, enter your Zealand email adress] stricter version for studentmails
            public string Email { get; set; }
            
            [Required]
            [Phone]
            [RegularExpression(@"^\+?[0-9]{3,15}$", ErrorMessage = "Please, enter valid phone number")]
            public string PhoneNo { get; set; }
            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            [PasswordFoolproof("Name","Email","PhoneNo")]
            public string Password { get; set; }
            [Required]
            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
            public bool Driver { get; set; }
        }
        IUserService service;
        SingletonUser User;
        [BindProperty]
        public InputModel newUser { get; set; }
        public RegisterModel(IUserService i, SingletonUser u)
        {
            service = i;
            User = u;
        }
        public void OnGet()
        {
            
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            ZuberUser NewToDatabase = new ZuberUser();
            NewToDatabase.Name = newUser.Name;
            NewToDatabase.Email = newUser.Email;
            NewToDatabase.PhoneNo = newUser.PhoneNo;
            NewToDatabase.Password = newUser.Password;
            NewToDatabase.Driver = newUser.Driver;
            service.AddZuberUser(NewToDatabase);
            User.Login(service.GetZuberUser(NewToDatabase.Email));
            return RedirectToPage("dotSettings");
        }
    }
}
