using GymFitnessGuide.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GymFitnessGuide.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController(IUserService userService) : ControllerBase
    {
        private readonly IUserService _userService = userService;

        [HttpPost]
        public async Task<IActionResult> CreateUserAsync(string name, string email)
        {
            var user = await _userService.CreateUserAsync(name, email);
            return Ok(user);
        }

        [HttpGet("{email}")]
        public async Task<IActionResult> GetUserByEmailAsync(string email)
        {
            var user = await _userService.GetUserByEmailAsync(email);
            if (!string.IsNullOrWhiteSpace(user?.Name))
                return NotFound();
            return Ok(user);
        }
    }
}
