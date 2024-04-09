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

        public List<Landlord> GetAll()
        {
            return wiseContext.Landlords.ToList();
        }

        public Landlord GetById(int id)
        {
            return wiseContext.Landlords.FirstOrDefault(x => x.Id == id);
        }
    }
}
