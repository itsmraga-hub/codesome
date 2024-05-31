using codesome.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace codesome.Data.Services.Courses
{
    public class CategoriesService : ICategoriesService
    {
        private readonly codesomeContext _context;
        private readonly ILogger<CategoriesService> _logger;
        public CategoriesService(codesomeContext context, ILogger<CategoriesService> logger)
        {
            _context = context;
            _logger = logger;
        }
        public Task CreateCategoryAsync(Category category)
        {
            if (category == null)
            {
                throw new ArgumentNullException(nameof(category));
            }
            _context.Categories.Add(category);
            _context.SaveChanges();
            
            return Task.CompletedTask;
        }

        public async Task<List<Category>?> GetCategoriesAsync()
        {
            if (_context.Categories == null)
            {
                return null!;
            }
            return await _context.Categories.ToListAsync();
        }

        public Task<Category?> GetCategoryAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Lesson>> GetCategoryCoursesAsync(int categoryId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> PutCategoryAsync(int id, Category category)
        {
            throw new NotImplementedException();
        }
    }
}
