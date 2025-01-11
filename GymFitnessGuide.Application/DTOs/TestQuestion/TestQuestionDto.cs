using GymFitnessGuide.Application.DTOs.TestAnswer;

namespace GymFitnessGuide.Application.DTOs.TestQuestion
{
    public class TestQuestionDto
    {
        public int Id { get; set; }
        public required string QuestionText { get; set; }
        public List<TestAnswerDto> Answers { get; set; } = null!;
    }
}
