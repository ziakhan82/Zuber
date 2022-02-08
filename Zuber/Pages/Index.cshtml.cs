using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zuber.Services.EFServices;

namespace Zuber.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public SingletonUser User;

        public IndexModel(ILogger<IndexModel> logger, SingletonUser s)
        {
            _logger = logger;
            User = s;
        }

        public IActionResult OnGet()
        {
            //if (User.User==null)
            if (!User.SignedIn)
            {
                return RedirectToPage("Login");
            }
            return Page();
        }
    }
}
