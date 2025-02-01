using System.ComponentModel.DataAnnotations.Schema;

namespace GymFitnessGuide.Infrastructure.Entities
{
    [Table("testquestions")]
    public class TestQuestion
    {
        public int Id { get; set; }
        public required string Question { get; set; }
        public bool? IsOpen { get; set; } // Con esto voy a determinar si la pregunta es abierta o cerrada.

        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;

        public ICollection<QuestionOption?>? Options { get; set; }
    }
}
