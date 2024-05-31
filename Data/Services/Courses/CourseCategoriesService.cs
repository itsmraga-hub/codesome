using codesome.Data.Courses;
using codesome.Data.Models;

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

        public Task<CourseCategory> CreateCourseCategoryAsync(string categoryId, string courseId)
        {
            if (categoryId == null)
                return null!;
            if (courseId == null)
                return null!;
            if (_context.CourseCategories == null)
                return null!;
            CourseCategory courseCategory = new CourseCategory
            {
                CategoryId = categoryId,
                CourseId = courseId
            };
            _context.CourseCategories.Add(courseCategory);
            _context.SaveChanges();
            return Task.FromResult(courseCategory);
        }


        public Task<List<CourseCategory>?> GetCourseCategoriesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CourseCategory?> GetCourseCategoryAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Lesson>> GetCourseCategoryCoursesAsync(string categoryId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> PutCourseCategoryAsync(string id, Category category)
        {
            throw new NotImplementedException();
        }

    }
}
