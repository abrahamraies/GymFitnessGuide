namespace GymFitnessGuide.Application.DTOs.TestAnswer
{
    public class TestAnswerDto
    {
        public int Id { get; set; }
        public bool? Answer { get; set; }
        public int? SelectedOptionId { get; set; }
        public int QuestionId { get; set; }
        public int UserId { get; set; }
    }
}
