using codesome.Data.Courses;
using codesome.Data.Models;
using codesome.Data.Services.Users;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace codesome.Data.Services.Enrollments
{
    public class StudentEnrollmentService : IStudentEnrollmentService
    {
        private readonly codesomeContext _context;
        private readonly ILogger<UserService> _logger;
        public StudentEnrollmentService(codesomeContext context, ILogger<UserService> logger) { 
            _context = context;
            _logger = logger;
        }
        public Task<StudentEnrollment> EnrollStudentAsync(StudentEnrollment enrollment)
        {
            /*var enrollment = new StudentEnrollment
            {
                StudentId = studentId,
                CourseId = courseId,
            };*/
            var course = _context.Courses.Find(enrollment.CourseId);
            course!.StudentsEnrolled += 1;
            _context.Enrollments.Add(enrollment);

            _context.SaveChanges();
            return Task.FromResult(enrollment);
        }

        public Task<IEnumerable<StudentEnrollment>> GetCourseEnrollmentsAsync(string studentId)
        {
            throw new NotImplementedException();
        }

        public Task<List<StudentEnrollment>> GetStudentEnrollmentAsync(string courseId, string studentId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<StudentEnrollment>> GetStudentEnrollmentsAsync(string studentId)
        {
            // var course = _context.Courses.Find(courseId);
            var student = _context.Users.Find(studentId);
            var enrollments = await _context.Enrollments.Where(_ => _.StudentId == studentId).Include(_ => _.Course).Include(_ => _.Student).ToListAsync();
            _logger.LogInformation(JsonConvert.SerializeObject(enrollments));
            return enrollments;
        }

        public Task UnEnrollStudentAsync(string userId, string courseId)
        {
            /*var enrollment = new StudentEnrollment
            {
                StudentId = studentId,
                CourseId = courseId,
            };*/
            var enrollment = _context.Enrollments.Where(_ => _.CourseId == courseId && _.StudentId == userId).FirstOrDefault();
            var course = _context.Courses.Find(courseId);
            course!.StudentsEnrolled -= 1;
            _context.Enrollments.Remove(enrollment!);

            _context.SaveChanges();
            return Task.FromResult("Unenrolled successfully");
        }

        public Task<StudentEnrollment> UnenrollStudentAsync(string courseId, string studentId)
        {
            throw new NotImplementedException();
        }
    }
}
