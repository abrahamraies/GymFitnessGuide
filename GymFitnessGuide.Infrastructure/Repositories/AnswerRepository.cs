using GymFitnessGuide.Infrastructure.Data;
using GymFitnessGuide.Infrastructure.Entities;
using GymFitnessGuide.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GymFitnessGuide.Infrastructure.Repositories
{
    public class AnswerRepository(AppDbContext context) : IAnswerRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<bool> AddAsync(TestAnswer answer)
        {
            await _context.TestAnswers.AddAsync(answer);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<TestAnswer>> GetAllAsync()
        {
            return await _context.TestAnswers.ToListAsync();
        }

        public async Task<TestAnswer?> GetByIdAsync(int id)
        {
            return await _context.TestAnswers.FindAsync(id);
        }

        public async Task<IEnumerable<TestAnswer>> GetAnswersByUserIdAsync(int userId)
        {
            return await _context.TestAnswers
                .Include(a => a.Question)
                .Where(a => a.UserId == userId)
                .ToListAsync();
        }

        public async Task<bool> UpdateAsync(TestAnswer answer)
        {
            _context.TestAnswers.Update(answer);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var answer = await _context.TestAnswers.FindAsync(id);
            if (answer == null) return false;
            _context.TestAnswers.Remove(answer);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
