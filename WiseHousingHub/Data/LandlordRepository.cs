using WiseHousingHub.Models;
using Microsoft.EntityFrameworkCore;
using WiseHousingHub.Data;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;

namespace WiseHousingHub.Data
{
    public class LandlordRepository : ILandlordRepository
    {
        private readonly WiseContext wiseContext;
        private readonly UserManager<ApplicationUser> userManager;

        public LandlordRepository(WiseContext context, UserManager<ApplicationUser> userManager)
        {
            this.wiseContext = context;
            this.userManager = userManager;
        }

        public async Task AddAsync(ApplicationUser user)
        {
            await userManager.CreateAsync(user);
        }

        public async Task DeleteAsync(string userId)
        {
            var user = await userManager.FindByIdAsync(userId);
            if (user != null)
            {
                await userManager.DeleteAsync(user);
            }
        }

        public async Task<List<ApplicationUser>> GetAllAsync()
        {
            return await userManager.Users.ToListAsync();
        }

        public async Task<ApplicationUser> GetByIdAsync(string userId)
        {
            return await userManager.FindByIdAsync(userId);
        }

        public async Task UpdateAsync(ApplicationUser user)
        {
            await userManager.UpdateAsync(user);
        }
    }
}

