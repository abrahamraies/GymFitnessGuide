namespace GymFitnessGuide.Infrastructure.Entities
{
    public class UserProfile
    {
        public int UserId { get; set; }
        public User User { get; set; } = null!;

        public int ProfileId { get; set; }
        public Profile Profile { get; set; } = null!;
    }
}
