using AutoMapper;
using GymFitnessGuide.Application.DTOs.Category;
using GymFitnessGuide.Application.DTOs.QuestionOption;
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
            CreateMap<User, UserUpdateDto>().ReverseMap()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CategoryCreateDto>().ReverseMap();
            CreateMap<Category, CategoryUpdateDto>().ReverseMap()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

                CreateMap<TestQuestion, TestQuestionDto>()
                .ForMember(dest => dest.Options, opt => opt.MapFrom(src => src.Options));
            CreateMap<TestQuestion, TestQuestionCreateDto>().ReverseMap()
                .ForMember(dest => dest.Options, opt => opt.MapFrom(src => src.Options ?? new List<QuestionOptionCreateDto>()));
            CreateMap<TestQuestion, TestQuestionUpdateDto>().ReverseMap()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<QuestionOptionCreateDto, QuestionOption>().ReverseMap();
            CreateMap<QuestionOption, QuestionOptionDto>().ReverseMap()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<TestAnswer, TestAnswerDto>().ReverseMap();
            CreateMap<TestAnswer, TestAnswerCreateDto>().ReverseMap();
            CreateMap<TestAnswer, TestAnswerUpdateDto>().ReverseMap()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Recommendation, RecommendationDto>().ReverseMap();
            CreateMap<Recommendation, RecommendationCreateDto>().ReverseMap();
            CreateMap<Recommendation, RecommendationUpdateDto>().ReverseMap()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
