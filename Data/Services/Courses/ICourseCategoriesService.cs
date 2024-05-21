using codesome.Data.Courses;
using codesome.Data.Models;

namespace codesome.Data.Services.Courses
{
    public interface ICourseCategoriesService
    {
        Task<List<CourseCategory>?> GetCourseCategoriesAsync();
        Task<CourseCategory?> GetCourseCategoryAsync(int id);
        Task<bool> PutCourseCategoryAsync(int id, CourseCategory courseCategory);
        Task CreateCourseCategoryAsync(Course course);
        Task<List<Lesson>> GetCourseCategoryCoursesAsync(int courseCategoryId);
    }
}
