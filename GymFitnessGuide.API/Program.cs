using GymFitnessGuide.Application.Interfaces;
using GymFitnessGuide.Application.Services;
using GymFitnessGuide.Infrastructure.Data;
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

//Repositories
RegisterRepositories(builder.Services);

// Services
RegisterServices(builder.Services);

// AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// CORS - Tengo que agrgear la url del frontend aca una vez que tenga el sitio deployado.
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder => builder.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});

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

// For alwaysData deployment
var ip = Environment.GetEnvironmentVariable("IP") ?? "0.0.0.0";
var port = Environment.GetEnvironmentVariable("PORT") ?? "5000";

app.Urls.Add($"http://{ip}:{port}");

app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseAuthorization();
app.MapControllers();
app.Run();

#region Methods for registering services and repositories
void RegisterRepositories(IServiceCollection services)
{
    services.AddScoped<IAnswerRepository, AnswerRepository>();
    services.AddScoped<ICategoryRepository, CategoryRepository>();
    services.AddScoped<IQuestionRepository, QuestionRepository>();
    services.AddScoped<IRecommendationRepository, RecommendationRepository>();
    services.AddScoped<IUserRepository, UserRepository>();
}

void RegisterServices(IServiceCollection services)
{
    services.AddScoped<IAnswerService, AnswerService>();
    services.AddScoped<ICategoryService, CategoryService>();
    services.AddScoped<IQuestionService, QuestionService>();
    services.AddScoped<IRecommendationService, RecommendationService>();
    services.AddScoped<IUserService, UserService>();
}
#endregion