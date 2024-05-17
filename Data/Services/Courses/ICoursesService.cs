using codesome.Data.Courses;
using codesome.Data.Models;

namespace codesome.Data.Services.Courses
{
    public interface ICoursesService
    {
        Task<List<Course>?> GetCoursesAsync();
        Task<Course?> GetCourseAsync(int id);
        Task<bool> PutCourseAsync(int id, Course course);
        Task CreateCourseAsync(Course course);
        Task<List<Lesson>> GetCourseLessonsAsync(int courseId);
    }
}
