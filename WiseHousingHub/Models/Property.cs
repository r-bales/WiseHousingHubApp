using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WiseHousingHub.Models
{
    public class Property
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string Zip { get; set; }
        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string LeaseType { get; set; }
        [Required]
        public double SquareFeet { get; set; }
        [Required]
        public int Bedrooms { get; set; }
        [Required]
        public int Bathrooms { get; set; }
        [Required]
        public int ParkingSpaces { get; set; }
        [Required]
        public bool Furnished { get; set; }
        [Required]
        public bool WheelchairAccessible { get; set; }
        [Required]
        public bool PetsAllowed { get; set; }
        
        public string LandlordId { get; set; }
        public DateTime DateListed { get; set; }
        public string ImageFileName { get; set; }

        [NotMapped]
        public IFormFile Upload { get; set; }
        
        public ApplicationUser Landlord { get; set; }
        public bool IsVerified { get; set; } = false;



    }
}