using codesome.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace codesome.Data.Services.Courses
{
    public class CourseCategoriesService : ICourseCategoriesService
    {
        private readonly codesomeContext _context;
        private readonly ILogger<CourseCategoriesService> _logger;
        public CourseCategoriesService(codesomeContext context, ILogger<CourseCategoriesService> logger)
        {
            _context = context;
            _logger = logger;
        }
        public Task CreateCourseCategoryAsync(CourseCategory courseCategory)
        {
            if (courseCategory == null)
            {
                throw new ArgumentNullException(nameof(courseCategory));
            }
            _context.CourseCategories.Add(courseCategory);
            _context.SaveChanges();
            
            return Task.CompletedTask;
        }

        public async Task<List<CourseCategory>?> GetCourseCategoriesAsync()
        {
            if (_context.CourseCategories == null)
            {
                return null!;
            }
            return await _context.CourseCategories.ToListAsync();
        }

        public Task<CourseCategory?> GetCourseCategoryAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Lesson>> GetCourseCategoryCoursesAsync(int courseCategoryId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> PutCourseCategoryAsync(int id, CourseCategory courseCategory)
        {
            throw new NotImplementedException();
        }
    }
}
