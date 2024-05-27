using codesome.Data.Courses;
using codesome.Data.Models;

namespace codesome.Data.Services.Courses
{
    public class CourseCategoryService : ICourseCategoriesService
    {
        private readonly codesomeContext _context;
        private readonly ILogger<CourseCategoryService> _logger;

        public CourseCategoryService(codesomeContext context, ILogger<CourseCategoryService> logger)
        {
            _context = context;
            _logger = logger;
        }

        Task<CourseCategory> ICourseCategoriesService.CreateCourseCategoryAsync(string categoryId, string courseId)
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

        Task<List<CourseCategory>?> ICourseCategoriesService.GetCourseCategoriesAsync()
        {
            throw new NotImplementedException();
        }

        Task<CourseCategory?> ICourseCategoriesService.GetCourseCategoryAsync(string id)
        {
            throw new NotImplementedException();
        }

        Task<List<Lesson>> ICourseCategoriesService.GetCourseCategoryCoursesAsync(string categoryId)
        {
            throw new NotImplementedException();
        }

        Task<bool> ICourseCategoriesService.PutCourseCategoryAsync(string id, Category category)
        {
            throw new NotImplementedException();
        }
    }
}
