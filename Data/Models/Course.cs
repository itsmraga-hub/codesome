using codesome.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace codesome.Data.Courses
{

    [Table("Courses")]
    public class Course : Base
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public float Price { get; set; }
        public DateTimeOffset StartDate { get; set; } = DateTimeOffset.Now;
        public DateTimeOffset EndDate { get; set; } = DateTimeOffset.Now;
        public int StudentsEnrolled { get; set; } = 0;
        public float Rating { get; set; }
        public string AuthorId { get; set; } = "";
        public User Author { get; set; } = null!;
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
        public ICollection<Category> CourseCategories { get; set; } = new List<Category>();
        public ICollection<CourseTag> CourseTags { get; set; } = new List<CourseTag>();

    }
}
