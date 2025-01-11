namespace GymFitnessGuide.Application.DTOs.TestAnswer
{
    public class TestAnswerDto
    {
        public int Id { get; set; }
        public required string AnswerText { get; set; }
        public bool IsCorrect { get; set; }
    }
}
