using codesome.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace codesome.Data.Services.Courses
{
    public class TagsService : ITagsService
    {
        private readonly codesomeContext _context;
        private readonly ILogger<TagsService> _logger;

        public TagsService(codesomeContext context, ILogger<TagsService> logger)
        {
            _context = context;
            _logger = logger;
        }
        public Task<Tag> CreateTagAsync(Tag tag)
        {
            if (tag == null)
            {
                throw new ArgumentNullException(nameof(tag));
            }
            _context.Tags.Add(tag);
            _context.SaveChanges();

            return Task.FromResult(tag);
        }

        public Task<Tag?> GetTagAsync(int id)
        {
            if (id == 0)
            {
                return null!;
            }
            if (_context.Tags == null)
            {
                return null!;
            }
            return Task.FromResult(_context.Tags.Find(id));
        }

        public Task<List<Lesson>> GetTagCoursesAsync(int categoryId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Tag>?> GetTagsAsync()
        {
            if (_context.Tags == null)
            {
                return null!;
            }
            List<Tag> tags = await _context.Tags.ToListAsync();
            return tags;
        }

        public Task<bool> PutTagAsync(int id, Tag category)
        {
            throw new NotImplementedException();
        }
    }
}
