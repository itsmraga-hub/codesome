using codesome.Data.Courses;
using codesome.Data.Models;

namespace codesome.Data.Services.Courses
{
    public interface ICategoriesService
    {
        Task<List<Category>?> GetCategoriesAsync();
        Task<Category?> GetCategoryAsync(int id);
        Task<bool> PutCategoryAsync(int id, Category category);
        Task CreateCategoryAsync(Category category);
        Task<List<Lesson>> GetCategoryCoursesAsync(int categoryId);
    }
}
