using GymFitnessGuide.Application.DTOs.TestQuestion;
using GymFitnessGuide.Infrastructure.Entities;

namespace GymFitnessGuide.Application.Interfaces
{
    public interface IQuestionService
    {
        Task<IEnumerable<TestQuestionDto>> GetAllTestQuestionsAsync();
        Task<TestQuestionDto?> GetTestQuestionByIdAsync(int id);
        Task<bool> CreateTestQuestionAsync(TestQuestionCreateDto createTestQuestionDto);
        Task<bool> UpdateTestQuestionAsync(int id, TestQuestionUpdateDto updateTestQuestionDto);
        Task<bool> DeleteTestQuestionAsync(int id);
    }
}
