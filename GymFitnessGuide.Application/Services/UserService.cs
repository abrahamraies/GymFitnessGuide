using GymFitnessGuide.Application.Interfaces;
using GymFitnessGuide.Infrastructure.Data;
using GymFitnessGuide.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace GymFitnessGuide.Application.Services
{
    public class UserService(AppDbContext dbContext) : IUserService
    {
        private readonly AppDbContext _dbContext = dbContext;

        public async Task<User> CreateUserAsync(string name, string email)
        {
            var user = new User
            {
                Name = name,
                Email = email
            };

            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
