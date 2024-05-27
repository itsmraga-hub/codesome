using codesome.Data.Models;
using codesome.Data.Services.Users;

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

        Task<IEnumerable<StudentEnrollment>> IStudentEnrollmentService.GetCourseEnrollmentsAsync(string studentId)
        {
            throw new NotImplementedException();
        }

        Task<StudentEnrollment> IStudentEnrollmentService.GetStudentEnrollmentAsync(string courseId, string studentId)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<StudentEnrollment>> IStudentEnrollmentService.GetStudentEnrollmentsAsync(string courseId)
        {
            throw new NotImplementedException();
        }

        Task<StudentEnrollment> IStudentEnrollmentService.UnenrollStudentAsync(string courseId, string studentId)
        {
            throw new NotImplementedException();
        }
    }
}
