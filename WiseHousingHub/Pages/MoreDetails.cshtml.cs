using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WiseHousingHub.Data;
using WiseHousingHub.Models;

namespace WiseHousingHub.Pages
{
    public class MoreDetailsModel : PageModel
    {
        private IPropertyRepository propertyRepo;
        private ILandlordRepository landlordRepo;
        public MoreDetailsModel(IPropertyRepository propertyRepository, ILandlordRepository landlordRepository)
        {
            this.propertyRepo = propertyRepository;
            this.landlordRepo = landlordRepository;
        }

        [FromRoute]
        public int Id { get; set; }

        [BindProperty]
        public Property Property { get; set; }
        
        public void OnGet()
        {
            Property = this.propertyRepo.GetById(Id);
            Property.Landlord = this.landlordRepo.GetById(Property.LandlordId);
            
        }
    }
}
