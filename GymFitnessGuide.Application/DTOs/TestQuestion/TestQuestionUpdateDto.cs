using GymFitnessGuide.Application.DTOs.QuestionOption;

namespace GymFitnessGuide.Application.DTOs.TestQuestion
{
    public class TestQuestionUpdateDto
    {
        public string? Question { get; set; }

        public int? CategoryId { get; set; }

        public bool? IsOpen { get; set; }

        public ICollection<QuestionOptionDto?>? Options { get; set; }
    }
}
