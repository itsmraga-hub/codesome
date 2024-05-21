using codesome.Data.Courses;
using codesome.Data.Models;

namespace codesome.Data.Services.Courses
{
    public interface ICategoriesService
    {
        Task<List<Category>?> GetCourseCategoriesAsync();
        Task<Category?> GetCourseCategoryAsync(int id);
        Task<bool> PutCourseCategoryAsync(int id, Category category);
        Task CreateCourseCategoryAsync(Category category);
        Task<List<Lesson>> GetCourseCategoryCoursesAsync(int categoryId);
    }
}
