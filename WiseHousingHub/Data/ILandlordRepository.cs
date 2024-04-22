using System.Collections.Generic;
using System.Threading.Tasks;
using WiseHousingHub.Models;

namespace WiseHousingHub.Data
{
    public interface ILandlordRepository
    {
        Task AddAsync(ApplicationUser user);
        Task DeleteAsync(string userId);
        Task<List<ApplicationUser>> GetAllAsync();
        Task<ApplicationUser> GetByIdAsync(string userId);
        Task UpdateAsync(ApplicationUser user);
    }
}

