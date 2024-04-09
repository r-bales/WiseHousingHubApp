using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WiseHousingHub.Data;
using WiseHousingHub.Models;

namespace WiseHousingHub.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private IPropertyRepository propertyRepo;

        public List<Property> Properties { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IPropertyRepository propertyRepo)
        {
            _logger = logger;
            this.propertyRepo = propertyRepo;
        }

        public void OnGet()
        {
            Properties = propertyRepo.GetAll();

        }
    }
}