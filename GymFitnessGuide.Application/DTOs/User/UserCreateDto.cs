namespace GymFitnessGuide.Application.DTOs.User
{
    public class UserCreateDto
    {
        public required string Email { get; set; }
        public required string Name { get; set; }
        public int CategoryId { get; set; }
    }
}
