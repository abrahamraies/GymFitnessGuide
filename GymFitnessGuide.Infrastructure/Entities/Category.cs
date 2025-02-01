using System.ComponentModel.DataAnnotations.Schema;

namespace GymFitnessGuide.Infrastructure.Entities
{
    [Table("categories")]
    public class Category
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        public ICollection<Recommendation> Recommendations { get; set; } = [];
        public ICollection<TestQuestion> TestQuestions { get; set; } = [];
        public ICollection<UserCategory> UserCategories { get; set; } = [];

    }
}
