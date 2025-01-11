namespace GymFitnessGuide.Application.DTOs.User
{
    public class UserUpdateDto
    {
        public required string Email { get; set; }
        public required string Name { get; set; }
        public int CategoryId { get; set; }
        public bool IsEnabled { get; set; }
    }
}
