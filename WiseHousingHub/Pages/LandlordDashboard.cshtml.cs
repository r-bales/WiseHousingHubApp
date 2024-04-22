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
        public string userId { get; set; }

        [BindProperty]
        public ApplicationUser Landlord { get; set; }
        public async Task OnGetAsync()
        {
            Landlord = await landlordRepo.GetByIdAsync(userId);
            var properties = this.propertyRepo.GetPropertiesByLandlordId(userId);

            foreach (var property in properties)
            {
                Landlord.Properties.Add(property);
            }
            
        }
    }
}
