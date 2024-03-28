using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WiseHousingHub.Data;
using WiseHousingHub.Models;

namespace WiseHousingHub.Pages
{
    public class AdminDashboardModel : PageModel
    {
        private IPropertyRepository propertyRepo;

        public List<Property> Properties { get; set; }
        public AdminDashboardModel(IPropertyRepository propertyRepository)
        {
            this.propertyRepo = propertyRepository;
        }
        public void OnGet()
        {
            Properties = propertyRepo.GetAll();
        }
    }
}
