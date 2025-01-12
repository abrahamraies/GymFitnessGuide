namespace GymFitnessGuide.Application.DTOs.TestAnswer
{
    public class TestAnswerDto
    {
        public int Id { get; set; }
        public required string Answer { get; set; }
        public int QuestionId { get; set; }
        public int UserId { get; set; }
    }
}
