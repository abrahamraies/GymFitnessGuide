using AutoMapper;
using GymFitnessGuide.Application.DTOs.Recommendation;
using GymFitnessGuide.Application.DTOs.TestAnswer;
using GymFitnessGuide.Application.Interfaces;
using GymFitnessGuide.Infrastructure.Entities;
using GymFitnessGuide.Infrastructure.Repositories.Interfaces;

namespace GymFitnessGuide.Application.Services
{
    public class AnswerService(IAnswerRepository testAnswerRepository, IUserRepository userRepository, IRecommendationRepository recommendationRepository, IQuestionRepository testQuestionRepository, IMapper mapper) : IAnswerService
    {
        private readonly IAnswerRepository _testAnswerRepository = testAnswerRepository;
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IRecommendationRepository _recommendationRepository = recommendationRepository;
        private readonly IQuestionRepository _testQuestionRepository = testQuestionRepository;
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

        public async Task<TestAnswerDto> CreateTestAnswerAsync(TestAnswerCreateDto createTestAnswerDto)
        {
            var answer = _mapper.Map<TestAnswer>(createTestAnswerDto);
            await _testAnswerRepository.AddAsync(answer);
            return _mapper.Map<TestAnswerDto>(answer);
        }

        public async Task<IEnumerable<RecommendationDto>> GetRecommendationsBasedOnTestAsync(int userId)
        {
            var userAnswers = await _testAnswerRepository.GetAnswersByUserIdAsync(userId);

            var categoryId = await CalculateCategoryBasedOnAnswersAsync(userAnswers);

            var user = await _userRepository.GetByIdAsync(userId) ?? throw new KeyNotFoundException("User not found.");

            user.UserCategories.Clear();
            user.UserCategories.Add(new UserCategory { UserId = userId, CategoryId = categoryId });
            await _userRepository.UpdateAsync(user);

            var recommendations = await _recommendationRepository.GetByCategoryIdAsync(categoryId);
            return _mapper.Map<IEnumerable<RecommendationDto>>(recommendations);
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

        private async Task<int> CalculateCategoryBasedOnAnswersAsync(IEnumerable<TestAnswer> answers)
        {
            var categoryScores = new Dictionary<int, int>();

            foreach (var answer in answers)
            {
                var question = await _testQuestionRepository.GetByIdAsync(answer.QuestionId);
                if (question == null) continue;

                if (categoryScores.ContainsKey(question.CategoryId))
                {
                    categoryScores[question.CategoryId]++;
                }
                else
                {
                    categoryScores[question.CategoryId] = 1;
                }
            }

            return categoryScores.OrderByDescending(cs => cs.Value)
                                 .FirstOrDefault()
                                 .Key;
        }
    }
}