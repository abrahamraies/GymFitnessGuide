using GymFitnessGuide.Application.DTOs.User;
using GymFitnessGuide.Infrastructure.Entities;

namespace GymFitnessGuide.Application.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAllUsersAsync();
        Task<UserDto?> GetUserByIdAsync(int id);
        Task<bool> CreateUserAsync(CreateUserDto createUserDto);
        Task<bool> UpdateUserAsync(int id, UpdateUserDto updateUserDto);
        Task<bool> DisableUserAsync(int id);
    }
}
