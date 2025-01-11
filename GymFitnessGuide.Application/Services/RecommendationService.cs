using GymFitnessGuide.Application.DTOs.Recommendation;
using GymFitnessGuide.Application.Interfaces;
using GymFitnessGuide.Infrastructure.Entities;
using GymFitnessGuide.Infrastructure.Repositories.Interfaces;

namespace GymFitnessGuide.Application.Services
{
    public class RecommendationService : IRecommendationService
    {
        private readonly IRecommendationRepository _recommendationRepository;

        public RecommendationService(IRecommendationRepository recommendationRepository)
        {
            _recommendationRepository = recommendationRepository;
        }

        public async Task<IEnumerable<RecommendationDto>> GetRecommendationsByCategoryAsync(int categoryId)
        {
            var recommendations = await _recommendationRepository.GetByCategoryIdAsync(categoryId);
            return recommendations.Select(r => new RecommendationDto
            {
                Id = r.Id,
                Title = r.Title,
                Description = r.Description,
                Url = r.Url
            });
        }

        public async Task<RecommendationDto?> GetByIdAsync(int id)
        {
            var recommendation = await _recommendationRepository.GetByIdAsync(id);
            if (recommendation == null) return null;

            return new RecommendationDto
            {
                Id = recommendation.Id,
                Title = recommendation.Title,
                Description = recommendation.Description,
                Url = recommendation.Url
            };
        }

        public async Task AddRecommendationAsync(CreateRecommendationDto dto)
        {
            var recommendation = new Recommendation
            {
                Title = dto.Title,
                Description = dto.Description,
                Url = dto.Url,
                CategoryId = dto.CategoryId
            };

            await _recommendationRepository.AddAsync(recommendation);
        }

        public async Task UpdateRecommendationAsync(int id, UpdateRecommendationDto dto)
        {
            var recommendation = await _recommendationRepository.GetByIdAsync(id);
            if (recommendation == null) throw new KeyNotFoundException("Recommendation not found.");

            recommendation.Title = dto.Title;
            recommendation.Description = dto.Description;
            recommendation.Url = dto.Url;
            recommendation.CategoryId = dto.CategoryId;

            await _recommendationRepository.UpdateAsync(recommendation);
        }

        public async Task DeleteRecommendationAsync(int id)
        {
            await _recommendationRepository.DeleteAsync(id);
        }
    }
}
