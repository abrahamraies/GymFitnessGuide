using GymFitnessGuide.Application.DTOs.TestAnswer;

namespace GymFitnessGuide.Application.Interfaces
{
    public interface IAnswerService
    {
        Task<IEnumerable<TestAnswerDto>> GetAllTestAnswersAsync();
        Task<TestAnswerDto?> GetTestAnswerByIdAsync(int id);
        Task<bool> CreateTestAnswerAsync(TestAnswerCreateDto createTestAnswerDto);
        Task<bool> UpdateTestAnswerAsync(int id, TestAnswerUpdateDto updateTestAnswerDto);
        Task<bool> DeleteTestAnswerAsync(int id);
    }
}
