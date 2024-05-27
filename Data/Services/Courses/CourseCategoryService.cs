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

        Task<CourseCategory> ICourseCategoriesService.CreateCourseCategoryAsync(int categoryId, int courseId)
        {
           if (categoryId == 0)
                return null!;
           if (courseId == 0)
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

        Task<CourseCategory?> ICourseCategoriesService.GetCourseCategoryAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<List<Lesson>> ICourseCategoriesService.GetCourseCategoryCoursesAsync(int categoryId)
        {
            throw new NotImplementedException();
        }

        Task<bool> ICourseCategoriesService.PutCourseCategoryAsync(int id, Category category)
        {
            throw new NotImplementedException();
        }
    }
}
