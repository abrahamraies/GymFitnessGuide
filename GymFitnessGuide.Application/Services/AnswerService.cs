using AutoMapper;
using GymFitnessGuide.Application.DTOs.TestAnswer;
using GymFitnessGuide.Application.Interfaces;
using GymFitnessGuide.Infrastructure.Entities;
using GymFitnessGuide.Infrastructure.Repositories.Interfaces;

namespace GymFitnessGuide.Application.Services
{
    public class AnswerService(IAnswerRepository testAnswerRepository, IMapper mapper) : IAnswerService
    {
        private readonly IAnswerRepository _testAnswerRepository = testAnswerRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<IEnumerable<TestAnswerDto>> GetAllTestAnswersAsync()
        {
            var answers = await _testAnswerRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<TestAnswerDto>>(answers);
        }

        public async Task<TestAnswerDto?> GetTestAnswerByIdAsync(int id)
        {
            var answer = await _testAnswerRepository.GetByIdAsync(id);
            return _mapper.Map<TestAnswerDto>(answer);
        }

        public async Task<bool> CreateTestAnswerAsync(TestAnswerCreateDto createTestAnswerDto)
        {
            var answer = _mapper.Map<TestAnswer>(createTestAnswerDto);
            return await _testAnswerRepository.AddAsync(answer);
        }

        public async Task<bool> UpdateTestAnswerAsync(int id, TestAnswerUpdateDto updateTestAnswerDto)
        {
            var answer = await _testAnswerRepository.GetByIdAsync(id);
            if (answer == null) return false;

            _mapper.Map(updateTestAnswerDto, answer);
            return await _testAnswerRepository.UpdateAsync(answer);
        }

        public async Task<bool> DeleteTestAnswerAsync(int id)
        {
            return await _testAnswerRepository.DeleteAsync(id);
        }
    }
}