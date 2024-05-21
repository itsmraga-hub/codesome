using codesome.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace codesome.Data.Courses
{
    [Table("Reviews")]
    public class Review : Base
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Comment { get; set; } = "";
        public int? Rating { get; set; }

        // Navigation properties
        public int CourseId { get; set; }
        public Course Course { get; set; } = null!;

        public int StudentId { get; set; }
        public User User { get; set; } = null!;
    }
}