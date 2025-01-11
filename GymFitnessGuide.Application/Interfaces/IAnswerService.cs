using GymFitnessGuide.Application.DTOs.TestAnswer;

namespace GymFitnessGuide.Application.Interfaces
{
    public interface IAnswerService
    {
        Task<IEnumerable<TestAnswerDto>> GetAllTestAnswersAsync();
        Task<TestAnswerDto?> GetTestAnswerByIdAsync(int id);
        Task<bool> CreateTestAnswerAsync(CreateTestAnswerDto createTestAnswerDto);
        Task<bool> UpdateTestAnswerAsync(int id, UpdateTestAnswerDto updateTestAnswerDto);
        Task<bool> DeleteTestAnswerAsync(int id);
    }
}
