using GymFitnessGuide.Infrastructure.Data;
using GymFitnessGuide.Infrastructure.Entities;
using GymFitnessGuide.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GymFitnessGuide.Infrastructure.Repositories
{
    public class RecommendationRepository(AppDbContext context) : IRecommendationRepository
    {
        private readonly AppDbContext _context = context;

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
            return await _context.Recommendations
                .Include(r => r.Category) 
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<bool> AddAsync(Recommendation recommendation)
        {
            await _context.Recommendations.AddAsync(recommendation);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAsync(Recommendation recommendation)
        {
            _context.Recommendations.Update(recommendation);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var recommendation = await GetByIdAsync(id);
            if (recommendation != null)
            {
                _context.Recommendations.Remove(recommendation);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
