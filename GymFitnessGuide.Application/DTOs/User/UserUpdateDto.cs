namespace GymFitnessGuide.Application.DTOs.User
{
    public class UserUpdateDto
    {
        public string? Email { get; set; }
        public string? Name { get; set; }
        public int CategoryId { get; set; }
        public bool IsEnabled { get; set; }
    }
}
