using System.ComponentModel.DataAnnotations.Schema;

namespace GymFitnessGuide.Infrastructure.Entities
{
    [Table("testanswers")]
    public class TestAnswer
    {
        public int Id { get; set; }

        public int QuestionId { get; set; }
        public TestQuestion Question { get; set; } = null!;

        public int UserId { get; set; }
        public User User { get; set; } = null!;

        public bool? Answer { get; set; }
        public int? SelectedOptionId { get; set; }
        public QuestionOption? SelectedOption { get; set; }
    }
}
