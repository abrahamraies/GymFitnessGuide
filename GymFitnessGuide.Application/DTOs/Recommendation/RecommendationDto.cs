namespace GymFitnessGuide.Application.DTOs.Recommendation
{
    public class RecommendationDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string? Url { get; set; }
        public int CategoryId { get; set; }
    }
}
