namespace GymFitnessGuide.Application.DTOs.TestAnswer
{
    public class UpdateTestAnswerDto
    {
        public required string AnswerText { get; set; }
        public bool IsCorrect { get; set; }
    }
}
