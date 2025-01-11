namespace GymFitnessGuide.Application.DTOs.User
{
    public class UserDto
    {
        public int Id { get; set; }
        public required string Email { get; set; }
        public required string Name { get; set; }
        public bool IsEnabled { get; set; }
    }
}
