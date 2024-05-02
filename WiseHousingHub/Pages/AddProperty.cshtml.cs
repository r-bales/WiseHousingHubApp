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

        // Constructor with dependency injection for necessary services
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

        // Called when form is submitted (HTTP POST)
        public async Task<IActionResult> OnPost()
        {
            // Check if submitted form is valid
            if (ModelState.IsValid) { return Page(); }

            // Get the currently logged in user
            ApplicationUser user = await usrMan.GetUserAsync(User);
            if (user == null)
            {
                // If user isn't authenticated, redirect to login page
                return RedirectToPage("/Account/Login", new { area = "Identity" });
            }

            // Assign current user as landlord of the property
            NewProperty.LandlordId = user.Id;

            // Check if image was uploaded
            if (NewProperty.Upload is not null)
            {
                // Assign file name of uploaded pic to ImageFileName property
                NewProperty.ImageFileName = NewProperty.Upload.FileName;

                // Save uploaded image to the server
                var file = Path.Combine(webEnv.ContentRootPath, "wwwroot/images", NewProperty.Upload.FileName);
                using (var fileStream = new FileStream(file, FileMode.Create))
                {
                    await NewProperty.Upload.CopyToAsync(fileStream);
                }
            }
            // Set date listed for the property to current date/time
            NewProperty.DateListed = DateTime.Now;
            this.propertyRepo.Add(NewProperty);

            return RedirectToPage("Index");
        }

    }
}
