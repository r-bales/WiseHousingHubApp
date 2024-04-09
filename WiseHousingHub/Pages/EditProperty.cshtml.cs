using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WiseHousingHub.Data;
using WiseHousingHub.Models;

namespace WiseHousingHub.Pages
{
    public class EditPropertyModel : PageModel
    {
        private IPropertyRepository propertyRepo;
        private IWebHostEnvironment webEnv;

        public EditPropertyModel(IPropertyRepository propertyRepository, IWebHostEnvironment environment)
        {
            this.propertyRepo = propertyRepository;
            this.webEnv = environment;
        }

        [FromRoute]
        public int Id { get; set; }

        [BindProperty]
        public Property EditProperty { get; set; }
        public void OnGet()
        {
            EditProperty = this.propertyRepo.GetById(Id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid) { return Page(); }

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

            return RedirectToPage("AdminDashboard");
            
        }
    }
}
