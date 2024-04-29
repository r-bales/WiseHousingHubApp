using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WiseHousingHub.Data;
using WiseHousingHub.Models;

namespace WiseHousingHub.Pages
{
    [Authorize]
    public class AddPropertyModel : PageModel
    {
        private IPropertyRepository propertyRepo;
        private IWebHostEnvironment webEnv;
        private UserManager<ApplicationUser> usrMan;

        public AddPropertyModel(IPropertyRepository propertyRepository, IWebHostEnvironment environment,
            UserManager<ApplicationUser> usrManager)
        {
            this.propertyRepo = propertyRepository;
            this.webEnv = environment;
            this.usrMan = usrManager;
        }

        [BindProperty]
        public Property NewProperty { get; set; }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid) { return Page(); }

            ApplicationUser user = await usrMan.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToPage("/Account/Login", new { area = "Identity" });
            }

            NewProperty.LandlordId = user.Id;

            if (NewProperty.Upload is not null)
            {
                NewProperty.ImageFileName = NewProperty.Upload.FileName;

                var file = Path.Combine(webEnv.ContentRootPath, "wwwroot/images", NewProperty.Upload.FileName);
                using (var fileStream = new FileStream(file, FileMode.Create))
                {
                    await NewProperty.Upload.CopyToAsync(fileStream);
                }
            }
            NewProperty.DateListed = DateTime.Now;
            this.propertyRepo.Add(NewProperty);

            return RedirectToPage("Index");
        }

    }
}
