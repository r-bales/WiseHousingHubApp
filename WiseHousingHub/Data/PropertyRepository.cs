using WiseHousingHub.Models;
using Microsoft.EntityFrameworkCore;
using WiseHousingHub.Data;

namespace WiseHousingHub.Data
{
    // Repository for managing property-related operations
    public class PropertyRepository : IPropertyRepository
    {
        private WiseContext wiseContext;

        // Constructor
        public PropertyRepository(WiseContext context)
        {
            this.wiseContext = context;
        }

        // Add a new property to the database
        public void Add(Property property)
        {
            this.wiseContext.Properties.Add(property);
            this.wiseContext.SaveChanges();
        }

        // Delete a property based on its ID from the database
        public void Delete(int id)
        {
            var deleteItem = wiseContext.Properties.First(x => x.Id == id);
            wiseContext.Properties.Remove(deleteItem);
            wiseContext.SaveChanges();
        }

        // Get all properties from the database
        public List<Property> GetAll()
        {
            return wiseContext.Properties.ToList();
        }

        // Get a property based on its ID from the database
        public Property GetById(int id)
        {
            return wiseContext.Properties.FirstOrDefault(x => x.Id == id);
        }

        // Get properties belong to a specific landlord by landlordID
        public List<Property> GetPropertiesByLandlordId(string landlordId)
        {
            return wiseContext.Properties.Where(p => p.LandlordId.Equals(landlordId)).ToList();
        }

        // Update existing property in the database
        public void Update(Property property)
        {
            wiseContext.Entry(property).State = EntityState.Modified;
            wiseContext.SaveChanges();
        }
    }
}
