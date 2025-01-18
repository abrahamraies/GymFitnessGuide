using GymFitnessGuide.Application.DTOs.TestAnswer;
using GymFitnessGuide.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GymFitnessGuide.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestAnswerController(IAnswerService testAnswerService) : ControllerBase
    {
        private readonly IAnswerService _testAnswerService = testAnswerService;

        [HttpGet]
        public async Task<IActionResult> GetAllTestAnswers()
        {
            var answers = await _testAnswerService.GetAllTestAnswersAsync();
            return Ok(answers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTestAnswerById(int id)
        {
            var answer = await _testAnswerService.GetTestAnswerByIdAsync(id);
            if (answer == null) return NotFound();
            return Ok(answer);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTestAnswer([FromBody] TestAnswerCreateDto newAnswer)
        {
            var createdAnswer = await _testAnswerService.CreateTestAnswerAsync(newAnswer);
            return CreatedAtAction(nameof(GetTestAnswerById), new { id = createdAnswer.Id }, createdAnswer);
        }

        [HttpPost("{userId}/process")]
        public async Task<IActionResult> ProcessTestAndGetRecommendations(int userId)
        {
            try
            {
                var recommendations = await _testAnswerService.GetRecommendationsBasedOnTestAsync(userId);
                return Ok(recommendations); //hay que ver porq mierda retorna vacio.
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTestAnswer(int id, [FromBody] TestAnswerUpdateDto updatedAnswer)
        {
            var success = await _testAnswerService.UpdateTestAnswerAsync(id, updatedAnswer);
            if (!success) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTestAnswer(int id)
        {
            var success = await _testAnswerService.DeleteTestAnswerAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}
