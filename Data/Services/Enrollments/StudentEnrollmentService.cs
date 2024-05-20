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
        public Task EnrollStudentAsync(string studentId, int courseId)
        {
            _context.Enrollments.Add(new StudentEnrollment
            {
                StudentId = studentId,
                CourseId = courseId,          
            });
        }
    }
}
