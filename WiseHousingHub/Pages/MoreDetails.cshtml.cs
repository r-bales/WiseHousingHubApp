using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WiseHousingHub.Data;
using WiseHousingHub.Models;
using System.Threading.Tasks;

namespace WiseHousingHub.Pages
{
    public class MoreDetailsModel : PageModel
    {
        private IPropertyRepository propertyRepo;
        private ILandlordRepository landlordRepo;

		// Constructor with dependency injections of propertyRepo and landlordRepo
		public MoreDetailsModel(IPropertyRepository propertyRepository, ILandlordRepository landlordRepository)
        {
            this.propertyRepo = propertyRepository;
            this.landlordRepo = landlordRepository;
        }

        [FromRoute]
        public int Id { get; set; }

        [BindProperty]
        public Property Property { get; set; }
        
        // When page requested, get property and its landlord
        public async Task OnGetAsync()
        {
            Property = this.propertyRepo.GetById(Id);
            Property.Landlord = await landlordRepo.GetByIdAsync(Property.LandlordId);
            
        }
    }
}
