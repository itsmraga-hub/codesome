using codesome.Data.Courses;
using codesome.Data.Models;

namespace codesome.Data.Services.Courses
{
    public interface ICoursesService
    {
        Task<List<Course>?> GetCoursesAsync();
        Task<Course?> GetCourseAsync(string id);
        Task<bool> PutCourseAsync(string id, Course course);
        Task CreateCourseAsync(Course course);
        Task<List<Lesson>> GetCourseLessonsAsync(string courseId);
    }
}
