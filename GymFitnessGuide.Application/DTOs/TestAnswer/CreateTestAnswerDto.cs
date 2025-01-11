namespace GymFitnessGuide.Application.DTOs.TestAnswer
{
    public class CreateTestAnswerDto
    {
        public required string AnswerText { get; set; }
        public bool IsCorrect { get; set; }
    }
}
