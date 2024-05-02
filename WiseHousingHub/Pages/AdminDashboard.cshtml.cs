using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WiseHousingHub.Data;
using WiseHousingHub.Models;

namespace WiseHousingHub.Pages
{
    // Only admin allowed to access
    [Authorize(Roles = "admin")]
    public class AdminDashboardModel : PageModel
    {
        private IPropertyRepository propertyRepo;

        public List<Property> Properties { get; set; }

		// Constructor with dependency injection of propertyRepo
		public AdminDashboardModel(IPropertyRepository propertyRepository)
        {
            this.propertyRepo = propertyRepository;
        }

        // When page requested, get all properties and store in list
        public void OnGet()
        {
            Properties = propertyRepo.GetAll();
        }

        // When verify button is pressed, verify property
        public async Task<IActionResult> OnPostVerify(int id)
        {
            // Get property with specified Id
            var property = propertyRepo.GetById(id);

            if (property != null)
            {
                property.IsVerified = true;
                propertyRepo.Update(property);
            }
            return RedirectToPage();
        }

		// When unverify button is pressed, unverify property
		public async Task<IActionResult> OnPostUnverify(int id)
		{
            // Get property with specified Id
			var property = propertyRepo.GetById(id);

			if (property != null)
			{
				property.IsVerified = false;
				propertyRepo.Update(property);
			}
			return RedirectToPage();
		}
	}
}
