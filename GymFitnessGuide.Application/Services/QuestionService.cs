using AutoMapper;
using GymFitnessGuide.Application.DTOs.TestQuestion;
using GymFitnessGuide.Application.Interfaces;
using GymFitnessGuide.Infrastructure.Entities;
using GymFitnessGuide.Infrastructure.Repositories.Interfaces;

namespace GymFitnessGuide.Application.Services
{
    public class QuestionService(IQuestionRepository testQuestionRepository, IMapper mapper) : IQuestionService
    {
        private readonly IQuestionRepository _testQuestionRepository = testQuestionRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<IEnumerable<TestQuestionDto>> GetAllTestQuestionsAsync()
        {
            var questions = await _testQuestionRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<TestQuestionDto>>(questions);
        }

        public async Task<TestQuestionDto?> GetTestQuestionByIdAsync(int id)
        {
            var question = await _testQuestionRepository.GetByIdAsync(id);
            return _mapper.Map<TestQuestionDto>(question);
        }

        public async Task<IEnumerable<TestQuestionDto>> GetByCategoryIdAsync(int id)
        {
            var question = await _testQuestionRepository.GetByCategoryIdAsync(id);
            return _mapper.Map<IEnumerable<TestQuestionDto>>(question);
        }

        public async Task<TestQuestion> CreateTestQuestionAsync(TestQuestionCreateDto createTestQuestionDto)
        {
            var question = _mapper.Map<TestQuestion>(createTestQuestionDto);
            await _testQuestionRepository.AddAsync(question);
            return question;
        }

        public async Task<bool> UpdateTestQuestionAsync(int id, TestQuestionUpdateDto updateTestQuestionDto)
        {
            var question = await _testQuestionRepository.GetByIdAsync(id);
            if (question == null) return false;

            _mapper.Map(updateTestQuestionDto, question);
            return await _testQuestionRepository.UpdateAsync(question);
        }

        public async Task<bool> DeleteTestQuestionAsync(int id)
        {
            return await _testQuestionRepository.DeleteAsync(id);
        }
    }
}
