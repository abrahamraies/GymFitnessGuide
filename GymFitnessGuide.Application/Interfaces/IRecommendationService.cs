using GymFitnessGuide.Application.DTOs.Recommendation;
using GymFitnessGuide.Infrastructure.Entities;

namespace GymFitnessGuide.Application.Interfaces
{
    public interface IRecommendationService
    {
        Task<IEnumerable<RecommendationDto>> GetAllRecommendationsAsync();
        Task<IEnumerable<RecommendationDto>> GetRecommendationsByCategoryAsync(int categoryId);
        Task<RecommendationDto?> GetByIdAsync(int id);
        Task<RecommendationDto> AddRecommendationAsync(RecommendationCreateDto createdRecommendationDto);
        Task<bool> UpdateRecommendationAsync(int id, RecommendationUpdateDto dto);
        Task<bool> DeleteRecommendationAsync(int id);
    }
}
