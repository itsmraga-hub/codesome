using codesome.Data.Models;

namespace codesome.Data.Services.Enrollments
{
    public interface IStudentEnrollmentService
    {
        Task<StudentEnrollment> EnrollStudentAsync(StudentEnrollment enrollment);
        Task UnEnrollStudentAsync(string userId, string courseId);
        Task<StudentEnrollment> UnenrollStudentAsync(string courseId, string studentId);
        Task<List<StudentEnrollment>> GetStudentEnrollmentAsync(string courseId, string studentId);
        Task<IEnumerable<StudentEnrollment>> GetStudentEnrollmentsAsync(string courseId);
        Task<IEnumerable<StudentEnrollment>> GetCourseEnrollmentsAsync(string studentId);

    }
}
