using GymFitnessGuide.Application.DTOs.TestAnswer;

namespace GymFitnessGuide.Application.DTOs.TestQuestion
{
    public class UpdateTestQuestionDto
    {
        public required string QuestionText { get; set; }
        public List<UpdateTestAnswerDto> Answers { get; set; } = null!;
    }
}
