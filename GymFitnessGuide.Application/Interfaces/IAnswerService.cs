using GymFitnessGuide.Application.DTOs.Recommendation;
using GymFitnessGuide.Application.DTOs.TestAnswer;

namespace GymFitnessGuide.Application.Interfaces
{
    public interface IAnswerService
    {
        Task<IEnumerable<TestAnswerDto>> GetAllTestAnswersAsync();
        Task<TestAnswerDto?> GetTestAnswerByIdAsync(int id);
        Task<TestAnswerDto> CreateTestAnswerAsync(TestAnswerCreateDto createTestAnswerDto);
        Task<IEnumerable<RecommendationDto>> GetRecommendationsBasedOnTestAsync(int userId);
        Task<bool> UpdateTestAnswerAsync(int id, TestAnswerUpdateDto updateTestAnswerDto);
        Task<bool> DeleteTestAnswerAsync(int id);
    }
}
