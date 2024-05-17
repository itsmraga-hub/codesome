using codesome.Data.Courses;
using codesome.Data.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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

            _context.Course.Add(course);
            _context.SaveChanges();

            return Task.CompletedTask;
        }

        public async Task<List<Course>?> GetCoursesAsync()
        {
            if (_context.Course == null)
            {
                return null;
            }
            return await _context.Course.ToListAsync();
        }

        public async Task<Course?> GetCourseAsync(int id)
        {
            if (_context.Course == null)
            {
                return null;
            }
            return await _context.Course.FindAsync(id);
        }

        public async Task<bool> PutCourseAsync(int id, Course course)
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

        private bool CourseExists(int id)
        {
            return _context.Course.Any(e => e.Id == id);
        }

        public Task<List<Lesson>> GetCourseLessonsAsync(int courseId)
        {
            if (_context.Course == null)
            {
                return null!;
            }
            return null!;
        }
    }
}
