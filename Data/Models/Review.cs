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
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Comment { get; set; } = "";
        public int? Rating { get; set; }

        // Navigation properties
        public string CourseId { get; set; } = "";
        public Course Course { get; set; } = null!;

        public string UserId { get; set; } = "";
        public User User { get; set; } = null!;
    }
}