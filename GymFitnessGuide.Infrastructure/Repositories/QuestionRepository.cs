using GymFitnessGuide.Infrastructure.Data;
using GymFitnessGuide.Infrastructure.Entities;
using GymFitnessGuide.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GymFitnessGuide.Infrastructure.Repositories
{
    public class QuestionRepository(AppDbContext context) : IQuestionRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<IEnumerable<TestQuestion>> GetAllAsync()
        {
            return await _context.TestQuestions
                .Include(q => q.Options)
                .ToListAsync();
        }

        public async Task<TestQuestion?> GetByIdAsync(int id)
        {
            return await _context.TestQuestions
                .Include(q => q.Options)
                .FirstOrDefaultAsync(q => q.Id == id);
        }

        public async Task<IEnumerable<TestQuestion>> GetByCategoryIdAsync(int categoryId)
        {
            return await _context.TestQuestions
                                 .Where(q => q.CategoryId == categoryId)
                                 .ToListAsync();
        }

        public async Task<bool> AddAsync(TestQuestion question)
        {
            await _context.TestQuestions.AddAsync(question);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAsync(TestQuestion question)
        {
            _context.TestQuestions.Update(question);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var question = await _context.TestQuestions.FindAsync(id);
            if (question == null) return false;
            _context.TestQuestions.Remove(question);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
