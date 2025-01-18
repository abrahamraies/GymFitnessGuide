using AutoMapper;
using GymFitnessGuide.Application.DTOs.Recommendation;
using GymFitnessGuide.Application.Interfaces;
using GymFitnessGuide.Infrastructure.Entities;
using GymFitnessGuide.Infrastructure.Repositories.Interfaces;

namespace GymFitnessGuide.Application.Services
{
    public class RecommendationService(IRecommendationRepository recommendationRepository, ICategoryRepository categoryRepository, IMapper mapper) : IRecommendationService
    {
        private readonly IRecommendationRepository _recommendationRepository = recommendationRepository;
        private readonly ICategoryRepository _categoryRepository = categoryRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<IEnumerable<RecommendationDto>> GetAllRecommendationsAsync()
        {
            var recommendations = await _recommendationRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<RecommendationDto>>(recommendations);
        }

        public async Task<IEnumerable<RecommendationDto>> GetRecommendationsByCategoryAsync(int categoryId)
        {
            var recommendations = await _recommendationRepository.GetByCategoryIdAsync(categoryId);
            return _mapper.Map<IEnumerable<RecommendationDto>>(recommendations);
        }

        public async Task<RecommendationDto?> GetByIdAsync(int id)
        {
            var recommendation = await _recommendationRepository.GetByIdAsync(id);
            if (recommendation == null) return null;
            return _mapper.Map<RecommendationDto>(recommendation);
        }

        public async Task<RecommendationDto> AddRecommendationAsync(RecommendationCreateDto createdRecommendationDto)
        {
            var recommendation = _mapper.Map<Recommendation>(createdRecommendationDto);
            await _recommendationRepository.AddAsync(recommendation);
            return _mapper.Map<RecommendationDto>(recommendation);
        }

        public async Task<bool> UpdateRecommendationAsync(int id, RecommendationUpdateDto updateRecommendationDto)
        {
            var recommendation = await _recommendationRepository.GetByIdAsync(id) ?? throw new KeyNotFoundException("Recommendation not found.");

            if (updateRecommendationDto.CategoryId.HasValue)
            {
                var categoryExists = await _categoryRepository.ExistsAsync(updateRecommendationDto.CategoryId.Value);
                if (!categoryExists)
                {
                    throw new ArgumentException("The provided category does not exist.");
                }

                recommendation.CategoryId = updateRecommendationDto.CategoryId.Value;
            }

            _mapper.Map(updateRecommendationDto, recommendation);
            return await _recommendationRepository.UpdateAsync(recommendation);
        }

        public async Task<bool> DeleteRecommendationAsync(int id)
        {
            return await _recommendationRepository.DeleteAsync(id);
        }
    }
}
