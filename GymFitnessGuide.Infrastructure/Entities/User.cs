namespace GymFitnessGuide.Infrastructure.Entities
{
    public class User
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }

        public ICollection<UserProfile> UserProfiles { get; set; } = [];
        public ICollection<TestAnswer> TestAnswers { get; set; } = [];
    }
}
