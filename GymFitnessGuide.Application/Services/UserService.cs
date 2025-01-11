using GymFitnessGuide.Application.Interfaces;
using GymFitnessGuide.Infrastructure.Data;
using GymFitnessGuide.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace GymFitnessGuide.Application.Services
{
    public class UserService(AppDbContext dbContext) : IUserService
    {
        private readonly AppDbContext _dbContext = dbContext;

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<User?> GetUserByIdAsync(int id)
        {
            return await _dbContext.Users.FindAsync(id);
        }

        public async Task<User> CreateUserAsync(User user)
        {
            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<User?> UpdateUserAsync(int id, User updatedUser)
        {
            var existingUser = await _dbContext.Users.FindAsync(id);
            if (existingUser == null)
            {
                return null;
            }

            existingUser.Name = updatedUser.Name;
            existingUser.Email = updatedUser.Email;

            await _dbContext.SaveChangesAsync();
            return existingUser;
        }

        public async Task<bool> DisableUserAsync(int id)
        {
            var user = await _dbContext.Users.FindAsync(id);
            if (user == null || !user.IsEnabled)
            {
                return false;
            }

            user.IsEnabled = false;
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
