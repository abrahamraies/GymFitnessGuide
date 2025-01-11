using GymFitnessGuide.Application.DTOs.User;
using GymFitnessGuide.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GymFitnessGuide.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IUserService userService) : ControllerBase
    {
        private readonly IUserService _userService = userService;

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserCreateDto newUser)
        {
            var createdUser = await _userService.CreateUserAsync(newUser);
            return CreatedAtAction(nameof(GetUserById), createdUser);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UserUpdateDto user)
        {
            var updatedUser = await _userService.UpdateUserAsync(id, user);
            if (updatedUser) return NotFound();
            return Ok(updatedUser);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var result = await _userService.DisableUserAsync(id);
            if (!result) return NotFound();
            return NoContent();
        }
    }
}
