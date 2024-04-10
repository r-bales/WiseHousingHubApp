using WiseHousingHub.Models;
using Microsoft.EntityFrameworkCore;
using WiseHousingHub.Data;

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
            this.wiseContext.Properties.Add(property);
            this.wiseContext.SaveChanges();
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
            return wiseContext.Properties.FirstOrDefault(x => x.Id == id);
        }

        public void Update(Property property)
        {
            wiseContext.Entry(property).State = EntityState.Modified;
            wiseContext.SaveChanges();
        }
    }
}
