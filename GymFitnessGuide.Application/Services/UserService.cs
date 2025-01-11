﻿using AutoMapper;
using GymFitnessGuide.Application.DTOs.User;
using GymFitnessGuide.Application.Interfaces;
using GymFitnessGuide.Infrastructure.Entities;
using GymFitnessGuide.Infrastructure.Repositories.Interfaces;

namespace GymFitnessGuide.Application.Services
{
    public class UserService(IUserRepository userRepository, IMapper mapper) : IUserService
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<UserDto>>(users);
        }

        public async Task<UserDto?> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            return _mapper.Map<UserDto>(user);
        }

        public async Task<bool> CreateUserAsync(CreateUserDto createUserDto)
        {
            var user = _mapper.Map<User>(createUserDto);
            return await _userRepository.AddAsync(user);
        }

        public async Task<bool> UpdateUserAsync(int id, UpdateUserDto updateUserDto)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null) return false;

            _mapper.Map(updateUserDto, user);
            return await _userRepository.UpdateAsync(user);
        }

        public async Task<bool> DisableUserAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null) return false;

            user.IsEnabled = false;
            return await _userRepository.UpdateAsync(user);
        }
    }
}
