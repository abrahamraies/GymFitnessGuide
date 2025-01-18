using AutoMapper;
using GymFitnessGuide.Application.DTOs.TestQuestion;
using GymFitnessGuide.Application.Interfaces;
using GymFitnessGuide.Infrastructure.Entities;
using GymFitnessGuide.Infrastructure.Repositories;
using GymFitnessGuide.Infrastructure.Repositories.Interfaces;

namespace GymFitnessGuide.Application.Services
{
    public class QuestionService(IQuestionRepository testQuestionRepository,ICategoryRepository categoryRepository, IMapper mapper) : IQuestionService
    {
        private readonly IQuestionRepository _testQuestionRepository = testQuestionRepository;
        private readonly ICategoryRepository _categoryRepository = categoryRepository;
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
            if ((createTestQuestionDto.IsOpen == null || createTestQuestionDto.IsOpen == false) && (createTestQuestionDto.Options != null && createTestQuestionDto.Options.Count != 0))
            {
                throw new ArgumentException("Closed questions cannot have options.");
            }

            if (createTestQuestionDto.IsOpen == true && (createTestQuestionDto.Options == null || createTestQuestionDto.Options.Count == 0))
            {
                throw new ArgumentException("Open questions must have at least one option.");
            }

            var category = await _categoryRepository.GetByIdAsync(createTestQuestionDto.CategoryId)
                   ?? throw new KeyNotFoundException("Category not found.");

            var question = _mapper.Map<TestQuestion>(createTestQuestionDto);
            question.Category = category;

            await _testQuestionRepository.AddAsync(question);
            return question;
        }

        public async Task<bool> UpdateTestQuestionAsync(int id, TestQuestionUpdateDto updateTestQuestionDto)
        {
            var question = await _testQuestionRepository.GetByIdAsync(id);
            if (question == null) return false;

            if (updateTestQuestionDto.CategoryId.HasValue)
            {
                var category = await _categoryRepository.GetByIdAsync(updateTestQuestionDto.CategoryId.Value) 
                    ?? throw new KeyNotFoundException("Category not found.");
                question.Category = category;
            }

            if (updateTestQuestionDto.IsOpen.HasValue)
            {
                if (!updateTestQuestionDto.IsOpen.Value)
                {
                    question.Options.Clear();
                }
                else if (updateTestQuestionDto.Options != null && updateTestQuestionDto.Options.Count != 0)
                {

                    var updatedOptions = new List<QuestionOption>();

                    foreach (var optionDto in updateTestQuestionDto.Options)
                    {
                        if (optionDto.Id.HasValue)
                        {
                            var existingOption = question.Options.FirstOrDefault(o => o.Id == optionDto.Id.Value);
                            if (existingOption != null)
                            {
                                existingOption.Text = optionDto.Text ?? existingOption.Text;
                                existingOption.CategoryId = optionDto.CategoryId ?? existingOption.CategoryId;
                                updatedOptions.Add(existingOption);
                            }
                        }
                        else
                        {
                            updatedOptions.Add(new QuestionOption
                            {
                                Text = optionDto.Text ?? "",
                                CategoryId = optionDto.CategoryId ?? question.CategoryId,
                                QuestionId = id
                            });
                        }
                    }

                    var optionsToRemove = question.Options
                    .Where(o => updatedOptions.All(uo => uo.Id != o.Id))
                    .ToList();

                    foreach (var option in optionsToRemove)
                    {
                        question.Options.Remove(option);
                    }

                    question.Options = updatedOptions;

                }
            }

            _mapper.Map(updateTestQuestionDto, question);

            return await _testQuestionRepository.UpdateAsync(question);
        }

        public async Task<bool> DeleteTestQuestionAsync(int id)
        {
            return await _testQuestionRepository.DeleteAsync(id);
        }
    }
}
