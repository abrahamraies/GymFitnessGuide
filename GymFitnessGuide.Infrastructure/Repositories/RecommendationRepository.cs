using GymFitnessGuide.Infrastructure.Data;
using GymFitnessGuide.Infrastructure.Entities;
using GymFitnessGuide.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GymFitnessGuide.Infrastructure.Repositories
{
    public class RecommendationRepository : IRecommendationRepository
    {
        private readonly AppDbContext _context;

        public RecommendationRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Recommendation>> GetAllAsync()
        {
            return await _context.Recommendations.ToListAsync();
        }

        public async Task<IEnumerable<Recommendation>> GetByCategoryIdAsync(int categoryId)
        {
            return await _context.Recommendations
                                 .Where(r => r.CategoryId == categoryId)
                                 .ToListAsync();
        }

        public async Task<Recommendation?> GetByIdAsync(int id)
        {
            return await _context.Recommendations.FindAsync(id);
        }

        public async Task AddAsync(Recommendation recommendation)
        {
            await _context.Recommendations.AddAsync(recommendation);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Recommendation recommendation)
        {
            _context.Recommendations.Update(recommendation);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var recommendation = await GetByIdAsync(id);
            if (recommendation != null)
            {
                _context.Recommendations.Remove(recommendation);
                await _context.SaveChangesAsync();
            }
        }
    }
}
