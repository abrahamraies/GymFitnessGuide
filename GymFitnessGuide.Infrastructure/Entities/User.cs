namespace GymFitnessGuide.Infrastructure.Entities
{
    public class User
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public bool IsEnabled { get; set; } = true;

        public ICollection<UserCategory> UserCategories { get; set; } = [];
        public ICollection<TestAnswer> TestAnswers { get; set; } = [];
    }
}
