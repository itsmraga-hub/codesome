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

        Task<IEnumerable<StudentEnrollment>> IStudentEnrollmentService.GetCourseEnrollmentsAsync(string studentId)
        {
            throw new NotImplementedException();
        }

        Task<StudentEnrollment> IStudentEnrollmentService.GetStudentEnrollmentAsync(int courseId, string studentId)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<StudentEnrollment>> IStudentEnrollmentService.GetStudentEnrollmentsAsync(string courseId)
        {
            throw new NotImplementedException();
        }

        Task<StudentEnrollment> IStudentEnrollmentService.UnenrollStudentAsync(int courseId, string studentId)
        {
            throw new NotImplementedException();
        }
    }
}
