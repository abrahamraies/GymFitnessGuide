using GymFitnessGuide.Application.DTOs.Category;

namespace GymFitnessGuide.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync();
        Task<CategoryDto?> GetCategoryByIdAsync(int id);
        Task<bool> CreateCategoryAsync(CategoryCreateDto createCategoryDto);
        Task<bool> UpdateCategoryAsync(int id, CategoryUpdateDto updateCategoryDto);
        Task<bool> DeleteCategoryAsync(int id);
    }
}