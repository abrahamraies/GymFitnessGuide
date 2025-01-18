using GymFitnessGuide.Application.DTOs.QuestionOption;

namespace GymFitnessGuide.Application.DTOs.TestQuestion
{
    public class TestQuestionDto
    {
        public int Id { get; set; }
        public required string Question { get; set; }
        public bool IsOpen { get; set; }

        public int CategoryId { get; set; }
        public ICollection<QuestionOptionDto> Options { get; set; } = [];

    }
}
