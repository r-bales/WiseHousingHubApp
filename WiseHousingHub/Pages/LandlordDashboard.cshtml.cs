using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WiseHousingHub.Data;
using WiseHousingHub.Models;

namespace WiseHousingHub.Pages
{
    [Authorize]
    public class LandlordDashboardModel : PageModel
    {
        private IPropertyRepository propertyRepo;
        private ILandlordRepository landlordRepo;

        // Constructor with dependency injections of propertyRepo and landlordRepo
        public LandlordDashboardModel(IPropertyRepository propertyRepository, ILandlordRepository landlordRepository)
        {
            this.propertyRepo = propertyRepository;
            this.landlordRepo = landlordRepository;
        }

        [FromRoute]
        public string userId { get; set; }

        [BindProperty]
        public ApplicationUser Landlord { get; set; }

        // When page requested, get logged in user and their specific properties
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
