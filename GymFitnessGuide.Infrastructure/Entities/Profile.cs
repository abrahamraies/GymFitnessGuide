namespace GymFitnessGuide.Infrastructure.Entities
{
    public class Profile
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        public ICollection<UserProfile> UserProfiles { get; set; } = [];
        public ICollection<Recommendation> Recommendations { get; set; } = [];
    }
}
