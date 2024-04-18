using WiseHousingHub.Models;

namespace WiseHousingHub.Data
{
    public interface IPropertyRepository
    {
        public void Add(Property property);
        public void Update(Property property);
        public Property GetById(int id);
        public List<Property> GetPropertiesByLandlordId(int landlordId);
        public List<Property> GetAll();
        public void Delete(int id);
    }
}
