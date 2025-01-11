using GymFitnessGuide.Application.DTOs.Recommendation;

namespace GymFitnessGuide.Application.Interfaces
{
    public interface IRecommendationService
    {
        Task<IEnumerable<RecommendationDto>> GetRecommendationsByCategoryAsync(int categoryId);
        Task<RecommendationDto?> GetByIdAsync(int id);
        Task AddRecommendationAsync(CreateRecommendationDto dto);
        Task UpdateRecommendationAsync(int id, UpdateRecommendationDto dto);
        Task DeleteRecommendationAsync(int id);
    }
}
