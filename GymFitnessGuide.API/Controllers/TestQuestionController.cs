using GymFitnessGuide.Application.DTOs.TestQuestion;
using GymFitnessGuide.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GymFitnessGuide.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestQuestionController(IQuestionService testQuestionService) : ControllerBase
    {
        private readonly IQuestionService _testQuestionService = testQuestionService;

        [HttpGet]
        public async Task<IActionResult> GetAllTestQuestions()
        {
            var questions = await _testQuestionService.GetAllTestQuestionsAsync();
            return Ok(questions);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTestQuestionById(int id)
        {
            var question = await _testQuestionService.GetTestQuestionByIdAsync(id);
            if (question == null) return NotFound();
            return Ok(question);
        }

        [HttpGet("random")]
        public async Task<IActionResult> GetRandomQuestions([FromQuery] int count = 10)
        {
            var questions = await _testQuestionService.GetRandomTestQuestions(count);

            if (questions == null || !questions.Any())
            {
                return NotFound("No questions available.");
            }

            var response = questions.Select(q => new
            {
                q.Id,
                q.Question,
                q.IsOpen,
                Options = q.IsOpen ? q.Options.Select(o => new { o.Id, o.Text }) : null
            });

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTestQuestion([FromBody] TestQuestionCreateDto newQuestion)
        {
            var createdQuestion = await _testQuestionService.CreateTestQuestionAsync(newQuestion);
            return CreatedAtAction(nameof(GetTestQuestionById), new { id = createdQuestion.Id }, newQuestion);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTestQuestion(int id, [FromBody] TestQuestionUpdateDto updatedQuestion)
        {
            var success = await _testQuestionService.UpdateTestQuestionAsync(id, updatedQuestion);
            if (!success) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTestQuestion(int id)
        {
            var success = await _testQuestionService.DeleteTestQuestionAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}
