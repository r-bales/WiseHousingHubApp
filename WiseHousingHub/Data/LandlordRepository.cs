using WiseHousingHub.Models;
using Microsoft.EntityFrameworkCore;
using WiseHousingHub.Data;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;

namespace WiseHousingHub.Data
{
    // Repository for managing landlord-related operations
    public class LandlordRepository : ILandlordRepository
    {
        private readonly WiseContext wiseContext;
        private readonly UserManager<ApplicationUser> userManager;
        
        // Constructor
        public LandlordRepository(WiseContext context, UserManager<ApplicationUser> userManager)
        {
            this.wiseContext = context;
            this.userManager = userManager;
        }

        // Add a new user asynchronously
        public async Task AddAsync(ApplicationUser user)
        {
            await userManager.CreateAsync(user);
        }

		// Delete a user based on their ID asynchronously
		public async Task DeleteAsync(string userId)
        {
            var user = await userManager.FindByIdAsync(userId);
            if (user != null)
            {
                await userManager.DeleteAsync(user);
            }
        }

		// Get all users asynchronously
		public async Task<List<ApplicationUser>> GetAllAsync()
        {
            return await userManager.Users.ToListAsync();
        }

		// Get a user based on their ID asynchronously
		public async Task<ApplicationUser> GetByIdAsync(string userId)
        {
            return await userManager.FindByIdAsync(userId);
        }

		// Update a user asynchronously
		public async Task UpdateAsync(ApplicationUser user)
        {
            await userManager.UpdateAsync(user);
        }
    }
}

