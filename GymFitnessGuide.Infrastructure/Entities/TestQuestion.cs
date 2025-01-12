namespace GymFitnessGuide.Infrastructure.Entities
{
    public class TestQuestion
    {
        public int Id { get; set; }
        public string Question { get; set; } = string.Empty;

        public ICollection<TestAnswer> TestAnswers { get; set; } = [];

        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;
    }
}
