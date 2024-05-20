using codesome.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace codesome.Data.Courses
{

    [Table("Courses")]
    public class Course
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public float Price { get; set; }
        public DateTimeOffset StartDate { get; set; } = DateTimeOffset.Now;
        public DateTimeOffset EndDate { get; set; } = DateTimeOffset.Now;
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.Now;
        public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.Now;
        public DateTimeOffset? DeletedAt { get; set; }
        public int StudentsEnrolled { get; set; } = 0;
        public float Rating { get; set; }
        public string CourseAuthorId { get; set; }
        public User Author { get; set; } = null!;
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
        public ICollection<Category> CourseCategories { get; set; }
        public ICollection<CourseTag> CourseTags { get; set; }
        public Course()
        {
        }

    }
}
