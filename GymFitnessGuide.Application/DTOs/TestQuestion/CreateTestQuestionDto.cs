using GymFitnessGuide.Application.DTOs.TestAnswer;

namespace GymFitnessGuide.Application.DTOs.TestQuestion
{
    public class CreateTestQuestionDto
    {
        public required string QuestionText { get; set; }
        public List<CreateTestAnswerDto> Answers { get; set; } = null!;
    }
}
