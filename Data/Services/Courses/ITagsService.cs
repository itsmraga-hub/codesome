using codesome.Data.Models;

namespace codesome.Data.Services.Courses
{
    public interface ITagsService
    {
        Task<List<Tag>?> GetTagsAsync();
        Task<Tag?> GetTagAsync(int id);
        Task<bool> PutTagAsync(int id, Tag category);
        Task<Tag> CreateTagAsync(Tag category);
        Task<List<Lesson>> GetTagCoursesAsync(int categoryId);
    }
}
