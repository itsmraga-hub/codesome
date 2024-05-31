using codesome.Data.Courses;
using codesome.Data.Models;

namespace codesome.Data.Services.Courses
{
    public interface ICourseCategoriesService
    {
        Task<List<CourseCategory>?> GetCourseCategoriesAsync();
        Task<CourseCategory?> GetCourseCategoryAsync(string id);
        Task<bool> PutCourseCategoryAsync(string id, Category category);
        Task<CourseCategory> CreateCourseCategoryAsync(string categoryId, string courseId);
        Task<List<Lesson>> GetCourseCategoryCoursesAsync(string categoryId);
    }
}
