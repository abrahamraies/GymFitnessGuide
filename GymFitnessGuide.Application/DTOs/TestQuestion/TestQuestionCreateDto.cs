using GymFitnessGuide.Application.DTOs.TestAnswer;

namespace GymFitnessGuide.Application.DTOs.TestQuestion
{
    public class TestQuestionCreateDto
    {
        public required string QuestionText { get; set; }
        public List<TestAnswerCreateDto> Answers { get; set; } = null!;

        public int CategoryId { get; set; }
    }
}
