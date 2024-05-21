using codesome.Data.Courses;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace codesome.Data.Models
{
    [Table("CourseCategories")]
    public class CourseCategory : Base
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; } = null!;
        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;
        public ICollection<Course> Courses { get; set; } = new List<Course>();
        public ICollection<Category> AllCategories { get; } = new List<Category>();
        public ICollection<CourseTag> CourseTags { get; set; } = new List<CourseTag>();
    }
}
