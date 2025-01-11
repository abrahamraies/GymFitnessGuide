namespace GymFitnessGuide.Infrastructure.Entities
{
    public class Recommendation
    {
        public int Id { get; set; }
        public string Resource { get; set; } = string.Empty;

        public int ProfileId { get; set; }
        public Profile Profile { get; set; } = null!;
    }
}
