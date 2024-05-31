using codesome.Data.Courses;
using codesome.Data.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace codesome.Data.Services.Courses
{
    public class CoursesService : ICoursesService
    {
        private readonly codesomeContext _context;
        private readonly ILogger<CoursesService> _logger;

        public CoursesService(codesomeContext context, ILogger<CoursesService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public Task<Course> CreateCourseAsync(Course course)
        {
            if (course == null)
            {
                throw new ArgumentNullException(nameof(course));
            }

            _context.Courses.Add(course);
            _context.SaveChanges();

            return Task.FromResult(course);
        }

        public async Task<List<Course>?> GetCoursesAsync()
        {
            if (_context.Courses == null)
            {
                return null;
            }
            
            return await _context.Courses.Include(_ => _.Author).ToListAsync();
        }

        public async Task<Course> GetCourseAsync(string id)
        {
            _logger.LogInformation("WIlliam");
            _logger.LogInformation(id);
            if (_context.Courses == null)
            {
                return null!;
            }
            var course = await _context.Courses.FindAsync(id);           
            // _logger.LogInformation($"Course: {JsonConvert.SerializeObject(course)}");
            return course!;
        }

        public async Task<bool> PutCourseAsync(string id, Course course)
        {
            if (id != course.Id)
            {
                return false;
            }

            _context.Entry(course).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseExists(id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }

            return true;
        }

        private bool CourseExists(string id)
        {
            return _context.Courses.Any(e => e.Id == id);
        }

        public Task<List<Lesson>> GetCourseLessonsAsync(string courseId)
        {
            if (_context.Courses == null)
            {
                return null!;
            }
            return null!;
        }
    }
}
