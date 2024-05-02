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

		// Constructor with dependency injection for necessary services
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

        // Called when user edits property and clicks submit button
        public async Task<IActionResult> OnPostEdit()
        {
            // Check if submitted form is valid
            if (ModelState.IsValid) { return Page(); }

            // Get the currently logged in user
            ApplicationUser user = await usrMan.GetUserAsync(User);
            if (user == null)
            {
                // If user isn't authenticted, redirect to login page
                return RedirectToPage("/Account/Login", new { area = "Identity" });
            }
            // Assign the current user as landlord of the property
            EditProperty.LandlordId = user.Id;

            // Check if image was uploaded
            if (EditProperty.Upload is not null)
            {
                // Assign file name of uploaded pic to ImageFileName property
                EditProperty.ImageFileName = EditProperty.Upload.FileName;

                // Save uploaded image to the server
                var file = Path.Combine(webEnv.ContentRootPath, "wwwroot/images", EditProperty.Upload.FileName);
                using (var fileStream = new FileStream(file, FileMode.Create))
                {
                    await EditProperty.Upload.CopyToAsync(fileStream);
                }
            }
            // Set date listed for the property to current date/time since modified by editing
            EditProperty.DateListed = DateTime.Now;
            // Have to reassign Id to property or gets lost
            EditProperty.Id = Id;

            this.propertyRepo.Update(EditProperty);

            return RedirectToPage("Index"); 
        }

        // Called when user clicks delete button
        public IActionResult OnPostDelete()
        {
            this.propertyRepo.Delete(Id);

            return RedirectToPage("Index");
        }
    }
}
