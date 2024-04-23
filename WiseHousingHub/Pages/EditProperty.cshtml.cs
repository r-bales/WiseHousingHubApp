using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WiseHousingHub.Data;
using WiseHousingHub.Models;

namespace WiseHousingHub.Pages
{
    [Authorize]
    public class EditPropertyModel : PageModel
    {
        private IPropertyRepository propertyRepo;
        private IWebHostEnvironment webEnv;
        private UserManager<ApplicationUser> usrMan;

        public EditPropertyModel(IPropertyRepository propertyRepository, IWebHostEnvironment environment,
            UserManager<ApplicationUser> usrManager)
        {
            this.propertyRepo = propertyRepository;
            this.webEnv = environment;
            this.usrMan = usrManager;
        }

        [FromRoute]
        public int Id { get; set; }

        [BindProperty]
        public Property EditProperty { get; set; }
        public void OnGet()
        {
            EditProperty = this.propertyRepo.GetById(Id);
        }

        public async Task<IActionResult> OnPostEdit()
        {
            if (ModelState.IsValid) { return Page(); }

            ApplicationUser user = await usrMan.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToPage("/Account/Login", new { area = "Identity" });
            }
            EditProperty.LandlordId = user.Id;

            if (EditProperty.Upload is not null)
            {
                EditProperty.ImageFileName = EditProperty.Upload.FileName;

                var file = Path.Combine(webEnv.ContentRootPath, "wwwroot/images", EditProperty.Upload.FileName);
                using (var fileStream = new FileStream(file, FileMode.Create))
                {
                    await EditProperty.Upload.CopyToAsync(fileStream);
                }
            }
            EditProperty.DateListed = DateTime.Now;
            EditProperty.Id = Id;

            this.propertyRepo.Update(EditProperty);

            return RedirectToPage("Index"); 
        }

        public IActionResult OnPostDelete()
        {
            this.propertyRepo.Delete(Id);

            return RedirectToPage("Index");
        }
    }
}
