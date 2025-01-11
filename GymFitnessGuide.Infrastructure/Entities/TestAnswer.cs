namespace GymFitnessGuide.Infrastructure.Entities
{
    public class TestAnswer
    {
        public int Id { get; set; }
        public string Answer { get; set; } = string.Empty;

        public int QuestionId { get; set; }
        public TestQuestion Question { get; set; } = null!;

        public int UserId { get; set; }
        public User User { get; set; } = null!;
    }
}
