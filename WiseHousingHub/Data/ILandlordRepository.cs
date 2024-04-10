using WiseHousingHub.Models;

namespace WiseHousingHub.Data
{
	public interface ILandlordRepository
	{
		public void Add(Landlord landlord);
		public void Update(Landlord landlord);
		public Landlord GetById(int id);
		public List<Landlord> GetAll();
		public void Delete(int id);
	}
}
