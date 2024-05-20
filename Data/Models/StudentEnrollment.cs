using codesome.Data.Courses;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace codesome.Data.Models
{
    [Table("StudentEnrollments")]
    public class StudentEnrollment
    {
        public int CourseId { get; set; }
        public Course Course { get; set; } = null!;
        public string StudentId { get; set; } = "";
        public User Student { get; set; } = null!;

        public DateTime DateEnrolled = DateTime.Now.Date;
        public DateTime? DateCompleted { get; set; }
    }
}
