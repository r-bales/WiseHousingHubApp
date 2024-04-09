using WiseHousingHub.Models;

namespace WiseHousingHub.Data
{
	public interface ILandlordRepository
	{
		public Landlord GetById(int id);
		public List<Landlord> GetAll();
	}
}
