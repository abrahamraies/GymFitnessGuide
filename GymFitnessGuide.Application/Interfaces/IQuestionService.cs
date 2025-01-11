using GymFitnessGuide.Application.DTOs.TestQuestion;
using GymFitnessGuide.Infrastructure.Entities;

namespace GymFitnessGuide.Application.Interfaces
{
    public interface IQuestionService
    {
        Task<IEnumerable<TestQuestionDto>> GetAllTestQuestionsAsync();
        Task<TestQuestionDto?> GetTestQuestionByIdAsync(int id);
        Task<bool> CreateTestQuestionAsync(CreateTestQuestionDto createTestQuestionDto);
        Task<bool> UpdateTestQuestionAsync(int id, UpdateTestQuestionDto updateTestQuestionDto);
        Task<bool> DeleteTestQuestionAsync(int id);
    }
}
