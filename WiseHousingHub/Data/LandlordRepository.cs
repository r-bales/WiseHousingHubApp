using WiseHousingHub.Models;
using Microsoft.EntityFrameworkCore;
using WiseHousingHub.Data;

namespace WiseHousingHub.Data
{
    public class LandlordRepository : ILandlordRepository
    {
        private WiseContext wiseContext;

        public LandlordRepository(WiseContext context)
        {
            this.wiseContext = context;
        }

        public void Add(Landlord landlord)
        {
            this.wiseContext.Landlords.Add(landlord);
            this.wiseContext.SaveChanges();
        }
        
        public void Delete(int id)
        {
            var deleteItem = wiseContext.Landlords.First(x => x.Id == id);
            wiseContext.Landlords.Remove(deleteItem);
            wiseContext.SaveChanges();
        }

        public List<Landlord> GetAll()
        {
            return wiseContext.Landlords.ToList();
        }

        public Landlord GetById(int id)
        {
            return wiseContext.Landlords.FirstOrDefault(x => x.Id == id);
        }

        public void Update(Landlord landlord)
        {
            wiseContext.Entry(landlord).State = EntityState.Modified;
            wiseContext.SaveChanges();
        }
    }
}
