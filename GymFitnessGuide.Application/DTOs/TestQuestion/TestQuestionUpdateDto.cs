using GymFitnessGuide.Application.DTOs.TestAnswer;

namespace GymFitnessGuide.Application.DTOs.TestQuestion
{
    public class TestQuestionUpdateDto
    {
        public required string QuestionText { get; set; }
        public List<TestAnswerUpdateDto> Answers { get; set; } = null!;
    }
}
