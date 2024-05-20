using codesome.Data.Models;

namespace codesome.Data.Services.Enrollments
{
    public interface IStudentEnrollmentService
    {
        Task<StudentEnrollment> EnrollStudentAsync(StudentEnrollment enrollment);
        Task<StudentEnrollment> UnenrollStudentAsync(int courseId, string studentId);
        Task<StudentEnrollment> GetStudentEnrollmentAsync(int courseId, string studentId);
        Task<IEnumerable<StudentEnrollment>> GetStudentEnrollmentsAsync(string courseId);
        Task<IEnumerable<StudentEnrollment>> GetCourseEnrollmentsAsync(string studentId);

    }
}
