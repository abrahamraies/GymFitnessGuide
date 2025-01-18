using GymFitnessGuide.Application.DTOs.QuestionOption;

namespace GymFitnessGuide.Application.DTOs.TestQuestion
{
    public class TestQuestionCreateDto
    {
        public required string Question { get; set; }

        public int CategoryId { get; set; }

        public bool? IsOpen { get; set; }

        public ICollection<QuestionOptionCreateDto>? Options { get; set; }
    }
}
