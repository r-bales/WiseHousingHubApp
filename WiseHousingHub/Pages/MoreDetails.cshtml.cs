using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WiseHousingHub.Data;
using WiseHousingHub.Models;

namespace WiseHousingHub.Pages
{
    public class MoreDetailsModel : PageModel
    {
        private IPropertyRepository propertyRepo;
        public MoreDetailsModel(IPropertyRepository propertyRepository)
        {
            this.propertyRepo = propertyRepository;
        }

        [FromRoute]
        public int Id { get; set; }

        [BindProperty]
        public Property Property { get; set; }
        public void OnGet()
        {
            Property = this.propertyRepo.GetById(Id);
        }
    }
}
