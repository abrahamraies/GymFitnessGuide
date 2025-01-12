using GymFitnessGuide.Application.DTOs.User;
using GymFitnessGuide.Infrastructure.Entities;

namespace GymFitnessGuide.Application.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAllUsersAsync();
        Task<UserDto?> GetUserByIdAsync(int id);
        Task<User> CreateUserAsync(UserCreateDto createUserDto);
        Task<bool> UpdateUserAsync(int id, UserUpdateDto updateUserDto);
        Task<bool> DisableUserAsync(int id);
    }
}
