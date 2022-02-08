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
    public class MapViewModel : PageModel
    {
        public SingletonUser User;
        public IDotService dService;
        public JsonDotService jSon;
        
        //[BindProperty]
        //public List<Dot> Dots { get; set; }
        public MapViewModel( SingletonUser s, IDotService d,JsonDotService j)
        {
            User = s;
            dService = d;
            //Dots = d.GetAllDots();
            jSon = j;
            jSon.UpdateJson();
        }
        public IActionResult OnGet()
        {
            //if (!User.SignedIn)
            //{
            //    return RedirectToPage("Login");
            //}
            return Page();
        }
    }
}
