using GymFitnessGuide.Infrastructure.Entities;

namespace GymFitnessGuide.Infrastructure.Repositories.Interfaces
{
    public interface IRecommendationRepository
    {
        Task<IEnumerable<Recommendation>> GetAllAsync();
        Task<IEnumerable<Recommendation>> GetByCategoryIdAsync(int categoryId);
        Task<Recommendation?> GetByIdAsync(int id);
        Task AddAsync(Recommendation recommendation);
        Task UpdateAsync(Recommendation recommendation);
        Task DeleteAsync(int id);
    }
}
