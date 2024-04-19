using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WiseHousingHub.Data;
using WiseHousingHub.Models;

namespace WiseHousingHub.Pages
{
    public class LandlordDashboardModel : PageModel
    {
        private IPropertyRepository propertyRepo;
        private ILandlordRepository landlordRepo;

        public LandlordDashboardModel(IPropertyRepository propertyRepository, ILandlordRepository landlordRepository)
        {
            this.propertyRepo = propertyRepository;
            this.landlordRepo = landlordRepository;
        }

        [FromRoute]
        public int Id { get; set; }

        [BindProperty]
        public Landlord Landlord { get; set; }
        public void OnGet()
        {
            Landlord = this.landlordRepo.GetById(Id);
            var properties = this.propertyRepo.GetPropertiesByLandlordId(Id);

            foreach (var property in properties)
            {
                Landlord.Properties.Add(property);
            }
            
        }
    }
}
