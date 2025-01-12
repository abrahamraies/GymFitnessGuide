namespace GymFitnessGuide.Application.DTOs.TestQuestion
{
    public class TestQuestionCreateDto
    {
        public required string Question { get; set; }

        public int CategoryId { get; set; }
    }
}
