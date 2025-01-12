namespace GymFitnessGuide.Application.DTOs.TestQuestion
{
    public class TestQuestionDto
    {
        public int Id { get; set; }
        public required string Question { get; set; }

        public int CategoryId { get; set; }
    }
}
