using codesome.Data.Courses;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace codesome.Data.Models
{
    [Table("CourseTags")]
    public class CourseTag : Base
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string CourseId { get; set; } = "";
        public Course Course { get; set; } = null!;
        public string TagId { get; set; } = "";
        public Tag Tag { get; set; } = null!;
    }
}
