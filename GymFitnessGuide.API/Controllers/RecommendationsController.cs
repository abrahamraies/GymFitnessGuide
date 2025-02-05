﻿using GymFitnessGuide.Application.DTOs.Recommendation;
using GymFitnessGuide.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace GymFitnessGuide.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecommendationsController(IRecommendationService recommendationService) : ControllerBase
    {
        private readonly IRecommendationService _recommendationService = recommendationService;

        [HttpGet]
        public async Task<IActionResult> GetAllRecommendations()
        {
            var recommendations = await _recommendationService.GetAllRecommendationsAsync();
            return Ok(recommendations);
        }

        [HttpGet("category/{categoryId}")]
        public async Task<IActionResult> GetByCategory(int categoryId, [FromServices] IMemoryCache cache)
        {
            string cacheKey = "recommendations_"+categoryId;

            if (!cache.TryGetValue(cacheKey, out IEnumerable<RecommendationDto>? recommendations))
            {
                recommendations = await _recommendationService.GetRecommendationsByCategoryAsync(categoryId);

                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromHours(1));

                cache.Set(cacheKey, recommendations, cacheOptions);
            }

            return Ok(recommendations);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var recommendation = await _recommendationService.GetByIdAsync(id);
            if (recommendation == null) return NotFound();
            return Ok(recommendation);
        }

        [HttpPost]
        public async Task<IActionResult> AddRecommendation([FromBody] RecommendationCreateDto newRecommendation)
        {
            var createdRecommendation = await _recommendationService.AddRecommendationAsync(newRecommendation);
            return CreatedAtAction(nameof(GetById), new { id = createdRecommendation.Id }, createdRecommendation);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRecommendation(int id, [FromBody] RecommendationUpdateDto recommendation)
        {
            try
            {
                var updatedRecommendation = await _recommendationService.UpdateRecommendationAsync(id, recommendation);

                if (updatedRecommendation) return NoContent();
                return Ok(updatedRecommendation);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecommendation(int id)
        {
            await _recommendationService.DeleteRecommendationAsync(id);
            return NoContent();
        }
    }
}
