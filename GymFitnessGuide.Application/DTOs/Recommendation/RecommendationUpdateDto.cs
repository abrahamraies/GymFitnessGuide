namespace GymFitnessGuide.Application.DTOs.Recommendation
{
    public class RecommendationUpdateDto
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Url { get; set; }
        public int? CategoryId { get; set; }
    }
}
