namespace GymFitnessGuide.Application.DTOs.User
{
    public class CreateUserDto
    {
        public required string Email { get; set; }
        public required string Name { get; set; }
        public int CategoryId { get; set; }
    }
}
