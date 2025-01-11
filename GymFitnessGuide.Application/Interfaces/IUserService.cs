using GymFitnessGuide.Infrastructure.Entities;

namespace GymFitnessGuide.Application.Interfaces
{
    public interface IUserService
    {
        Task<User> CreateUserAsync(string name, string email);
        Task<User?> GetUserByEmailAsync(string email);
    }
}
