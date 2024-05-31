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
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string CourseId { get; set; } = "";
        public Course Course { get; set; } = null!;
        public string CategoryId { get; set; } = "";
        public Category Category { get; set; } = null!;
  /*      public ICollection<Course> Courses { get; set; } = new List<Course>();
        public ICollection<Category> AllCategories { get; } = new List<Category>();
        public ICollection<CourseTag> CourseTags { get; set; } = new List<CourseTag>();*/
    }
}
