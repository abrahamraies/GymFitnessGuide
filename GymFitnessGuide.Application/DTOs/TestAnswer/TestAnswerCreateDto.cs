namespace GymFitnessGuide.Application.DTOs.TestAnswer
{
    public class TestAnswerCreateDto
    {
        public required string Answer { get; set; }
        public int QuestionId { get; set; }
        public int UserId { get; set; }
    }
}
