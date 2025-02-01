using System.ComponentModel.DataAnnotations.Schema;

namespace GymFitnessGuide.Infrastructure.Entities
{
    [Table("recommendations")]
    public class Recommendation
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public string? Url { get; set; }

        public int? CategoryId { get; set; }
        public Category Category { get; set; } = null!;
    }
}
