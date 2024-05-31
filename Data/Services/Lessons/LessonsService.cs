using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using codesome.Data.Models;
using codesome.Data.Courses;

namespace codesome.Data.Services.Lessons
{
    public class LessonsService : ILessonsService
    {
        private readonly codesomeContext _context;

        public LessonsService(codesomeContext context)
        {
            _context = context;
        }

        private bool LessonExists(string id)
        {
            return (_context.Lessons?.Any(e => e.Id == id)).GetValueOrDefault();
        }


        public Task<List<Lesson>?> GetLessonsAsync()
        {
            if (_context.Lessons == null)
            {
                return null!;
            }
            var lessons = _context.Lessons.ToListAsync();

            return lessons!;
        }

        public Task<List<Lesson>> GetCourseLessonsAsync(string id)
        {
            if (_context.Lessons == null)
            {
                return null!;
            }
            var lessons = _context.Lessons.Where(_ => _.CourseId == id).ToListAsync();

            return lessons!;
        }

        public Task<Lesson?> GetLessonAsync(int id)
        {
            if (_context.Lessons == null)
            {
                return null!;
            }
            var lesson = _context.Lessons.Include(l => l.Course);

            return (Task<Lesson?>)lesson;
        }

        public Task<bool> PutLessonAsync(int id, Lesson lesson)
        {
            throw new NotImplementedException();
        }

        public Task CreateLessonAsync(Lesson lesson)
        {
            if (lesson == null)
            {
                throw new ArgumentNullException(nameof(lesson));
            }

            _context.Lessons.Add(lesson);
            _context.SaveChanges();

            return Task.CompletedTask;
        }

    }
}
