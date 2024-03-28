using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WiseHousingHub.Data;
using WiseHousingHub.Models;

namespace WiseHousingHub.Pages
{
    public class AddPropertyModel : PageModel
    {
        private WiseContext wiseContext;
        private IWebHostEnvironment webEnv;

        public AddPropertyModel(WiseContext wiseContext, IWebHostEnvironment environment)
        {
            this.wiseContext = wiseContext;
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
            this.wiseContext.Properties.Add(NewProperty);
            this.wiseContext.SaveChanges();

            return RedirectToPage("Index");
        }

    }
}
