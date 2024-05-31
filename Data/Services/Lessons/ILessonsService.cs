using codesome.Data.Models;

namespace codesome.Data.Services.Lessons
{
    public interface ILessonsService
    {
        Task<List<Lesson>?> GetLessonsAsync();
        Task<Lesson?> GetLessonAsync(int id);
        Task<List<Lesson>> GetCourseLessonsAsync(string id);
        Task<bool> PutLessonAsync(int id, Lesson lesson);
        Task CreateLessonAsync(Lesson lesson);
    }
}
