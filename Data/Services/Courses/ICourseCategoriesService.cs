using codesome.Data.Courses;
using codesome.Data.Models;

namespace codesome.Data.Services.Courses
{
    public interface ICourseCategoriesService
    {
        Task<List<CourseCategory>?> GetCourseCategoriesAsync();
        Task<CourseCategory?> GetCourseCategoryAsync(int id);
        Task<bool> PutCourseCategoryAsync(int id, Category category);
        Task<CourseCategory> CreateCourseCategoryAsync(int categoryId, int courseId);
        Task<List<Lesson>> GetCourseCategoryCoursesAsync(int categoryId);
    }
}
