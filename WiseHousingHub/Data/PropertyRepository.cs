using WiseHousingHub.Models;

namespace WiseHousingHub.Data
{
    public class PropertyRepository : IPropertyRepository
    {
        private WiseContext wiseContext;

        public PropertyRepository(WiseContext context)
        {
            this.wiseContext = context;
        }
        public void Add(Property property)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Property> GetAll()
        {
            return wiseContext.Properties.ToList();
        }

        public Property GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Property property)
        {
            throw new NotImplementedException();
        }
    }
}
