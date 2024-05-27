using codesome.Data.Courses;
using codesome.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace codesome.Data.Services.Courses
{
    public class CoursesService : ICoursesService
    {
        private readonly codesomeContext _context;

        public CoursesService(codesomeContext context)
        {
            _context = context;
        }

        public Task CreateCourseAsync(Course course)
        {
            if (course == null)
            {
                throw new ArgumentNullException(nameof(course));
            }

            _context.Courses.Add(course);
            _context.SaveChanges();

            return Task.CompletedTask;
        }

        public async Task<List<Course>?> GetCoursesAsync()
        {
            if (_context.Courses == null)
            {
                return null;
            }
            return await _context.Courses.ToListAsync();
        }

        public async Task<Course?> GetCourseAsync(string id)
        {
            if (_context.Courses == null)
            {
                return null;
            }
            return await _context.Courses.FindAsync(id);
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
