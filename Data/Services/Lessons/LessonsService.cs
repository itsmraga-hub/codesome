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

        private bool LessonExists(int id)
        {
            return (_context.Lessons?.Any(e => e.Id == id)).GetValueOrDefault();
        }


        Task<List<Lesson>?> ILessonsService.GetLessonsAsync()
        {
            if (_context.Lessons == null)
            {
                return null!;
            }
            var lessons = _context.Lessons.Include(l => l.Course).ToListAsync();

            return lessons!;
        }


        Task<Lesson?> ILessonsService.GetLessonAsync(int id)
        {
            if (_context.Lessons == null)
            {
                return null!;
            }
            var lesson = _context.Lessons.Include(l => l.Course);

            return (Task<Lesson?>)lesson;
        }

        Task<bool> ILessonsService.PutLessonAsync(int id, Lesson lesson)
        {
            throw new NotImplementedException();
        }

        Task ILessonsService.CreateLessonAsync(Lesson lesson)
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
