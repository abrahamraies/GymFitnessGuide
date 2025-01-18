namespace GymFitnessGuide.Application.DTOs.QuestionOption
{
    public class QuestionOptionCreateDto
    {
        public required string Text { get; set; }
        public int CategoryId { get; set; }
    }
}
