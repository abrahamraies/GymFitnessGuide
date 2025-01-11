namespace GymFitnessGuide.Infrastructure.Entities
{
    public class Recommendation
    {
        public int Id { get; set; }
        public string Resource { get; set; } = string.Empty;

        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;
    }
}
