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
        public Task CreateCourseCategoryAsync(Course course)
        {
            throw new NotImplementedException();
        }

        public Task<List<CourseCategory>?> GetCourseCategoriesAsync()
        {
            throw new NotImplementedException();
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
