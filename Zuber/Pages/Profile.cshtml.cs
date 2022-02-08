using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Zuber.CustomAtributes;
using Zuber.Models;
using Zuber.Services.EFServices;
using Zuber.Services.Interfaces;

namespace Zuber.Pages
{
    public class ProfileModel : PageModel
    {
        //private readonly Zuber.Pages.Data.ImageContext _context;
        //private readonly IWebHostEnvironment _iweb;

        public IUserService service;
        public SingletonUser User;
        [BindProperty]
        public ZuberUser editableUser { get; set; }
        public ProfileModel(SingletonUser s,IUserService i)
        {
            User = s;
            service = i;
            
        }
        public IActionResult OnGet()
        {
            if (User.SignedIn)
            {
                editableUser = User.User;
                return Page();
            }
            //Anything
            else
            {
                return RedirectToPage("Login");
            }
        }
        public IActionResult OnPostSave()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            service.UpdateZuberUser(editableUser);
            User.Login(editableUser);
            if (editableUser.Driver)
            {
                return RedirectToPage("dotSettings");
            }

            return RedirectToPage("Index");
        }

        public IActionResult OnPostDelete()
        {
            service.DeleteZuberUser(User.User.Email);
            return RedirectToPage("Logout");
        }
        
       //{
       //     private readonly Zuber.Pages.Data.ImageContext _context;
       //     private readonly IWebHostEnvironment _iweb;

       //     public ProfileModel(RazorPages_CRUD_Fileupload.Data.ImageContext context, IWebHostEnvironment iweb)
       //     {
       //         _context = context;
       //         _iweb = iweb;

       //     }

       //     public IList<Imagesave> Imagesave { get; set; }

       //     public async Task OnGetAsync()
       //     {
       //         Imagesave = await _context.Imagesave.ToListAsync();
       //     }

       //     public async Task<IActionResult> OnPostAsync(IFormFile uploadfiles, Imagesave img)
       //     {
       //         if (!ModelState.IsValid)
       //         {
       //             return Page();
       //         }

       //         string imgext = Path.GetExtension(uploadfiles.FileName);
       //         if (imgext == ".jpg" || imgext == ".png")
       //         {
       //             var imgsave = Path.Combine(_iweb.WebRootPath, "Images", uploadfiles.FileName);
       //             var stream = new FileStream(imgsave, FileMode.Create);
       //             await uploadfiles.CopyToAsync(stream);
       //             stream.Close();

       //             img.Imgname = uploadfiles.FileName;
       //             img.Imgpath = imgsave;
       //             await _context.Imagesave.AddAsync(img);
       //             await _context.SaveChangesAsync();
       //         }

       //         return RedirectToPage("./Index");
       //     }
        //}
    }
}

