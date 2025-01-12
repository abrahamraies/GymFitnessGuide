using GymFitnessGuide.Application.DTOs.Recommendation;
using GymFitnessGuide.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GymFitnessGuide.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecommendationsController(IRecommendationService recommendationService) : ControllerBase
    {
        private readonly IRecommendationService _recommendationService = recommendationService;

        [HttpGet("category/{categoryId}")]
        public async Task<IActionResult> GetByCategory(int categoryId)
        {
            var recommendations = await _recommendationService.GetRecommendationsByCategoryAsync(categoryId);
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
        public async Task<IActionResult> AddRecommendation([FromBody] CreateRecommendationDto dto)
        {
            await _recommendationService.AddRecommendationAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = dto.CategoryId }, dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRecommendation(int id, [FromBody] UpdateRecommendationDto dto)
        {
            try
            {
                await _recommendationService.UpdateRecommendationAsync(id, dto);
                return NoContent();
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
