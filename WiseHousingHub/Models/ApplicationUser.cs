using Microsoft.AspNetCore.Identity;
using System.Security.Permissions;

namespace WiseHousingHub.Models
{
	public class ApplicationUser : IdentityUser
	{
		public string FirstName { get; set; } = "";
		public string LastName { get; set; } = ""; 
		public ICollection<Property> Properties { get; set; }


    }
}
