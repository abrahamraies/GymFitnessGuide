using AutoMapper;
using GymFitnessGuide.Application.DTOs.Category;
using GymFitnessGuide.Application.DTOs.Recommendation;
using GymFitnessGuide.Application.DTOs.TestAnswer;
using GymFitnessGuide.Application.DTOs.TestQuestion;
using GymFitnessGuide.Application.DTOs.User;
using GymFitnessGuide.Infrastructure.Entities;

namespace GymFitnessGuide.Application.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, UserCreateDto>().ReverseMap();
            CreateMap<User, UserUpdateDto>().ReverseMap();

            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CategoryCreateDto>().ReverseMap();
            CreateMap<Category, CategoryUpdateDto>().ReverseMap();

            CreateMap<TestQuestion, TestQuestionDto>().ReverseMap();
            CreateMap<TestQuestion, TestQuestionCreateDto>().ReverseMap();
            CreateMap<TestQuestion, TestQuestionUpdateDto>().ReverseMap();

            CreateMap<TestAnswer, TestAnswerDto>().ReverseMap();
            CreateMap<TestAnswer, TestAnswerCreateDto>().ReverseMap();
            CreateMap<TestAnswer, TestAnswerUpdateDto>().ReverseMap();

            CreateMap<Recommendation, RecommendationDto>().ReverseMap();
            CreateMap<Recommendation, RecommendationCreateDto>().ReverseMap();
            CreateMap<Recommendation, RecommendationUpdateDto>().ReverseMap();
        }
    }
}
