using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WiseHousingHub.Data;
using WiseHousingHub.Models;

namespace WiseHousingHub.Pages
{
    public class AddPropertyModel : PageModel
    {
        private IPropertyRepository propertyRepo;
        private IWebHostEnvironment webEnv;

        public AddPropertyModel(IPropertyRepository propertyRepository, IWebHostEnvironment environment)
        {
            this.propertyRepo = propertyRepository;
            this.webEnv = environment;
        }

        [BindProperty]
        public Property NewProperty { get; set; }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid) { return Page(); }

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
