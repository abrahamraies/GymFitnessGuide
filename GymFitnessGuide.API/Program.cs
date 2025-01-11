using AutoMapper;
using GymFitnessGuide.Application.DTOs.Category;
using GymFitnessGuide.Application.DTOs.TestAnswer;
using GymFitnessGuide.Application.DTOs.TestQuestion;
using GymFitnessGuide.Application.DTOs.User;
using GymFitnessGuide.Application.Interfaces;
using GymFitnessGuide.Application.Services;
using GymFitnessGuide.Infrastructure.Data;
using GymFitnessGuide.Infrastructure.Entities;
using GymFitnessGuide.Infrastructure.Repositories;
using GymFitnessGuide.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddUserSecrets<Program>();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
    ));

// Services
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IQuestionService, QuestionService>();
builder.Services.AddScoped<IAnswerService, AnswerService>();

//Repositories
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IQuestionRepository, QuestionRepository>();
builder.Services.AddScoped<IAnswerRepository, AnswerRepository>();

// AutoMapper - Crear una carpeta y configurarlo.
var config = new MapperConfiguration(cfg =>
{
    cfg.CreateMap<User, CreateUserDto>();
    cfg.CreateMap<User, UpdateUserDto>();
    cfg.CreateMap<User, UserDto>();

    cfg.CreateMap<TestQuestion, CreateTestQuestionDto>();
    cfg.CreateMap<User, TestQuestionDto>();
    cfg.CreateMap<User, UpdateTestQuestionDto>();

    cfg.CreateMap<TestAnswer, CreateTestAnswerDto>();
    cfg.CreateMap<TestAnswer, TestAnswerDto>();
    cfg.CreateMap<TestAnswer, UpdateTestAnswerDto>();

    cfg.CreateMap<Category, CategoryDto>();
    cfg.CreateMap<Category, CreateCategoryDto>();
    cfg.CreateMap<Category, UpdateCategoryDto>();
});

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();