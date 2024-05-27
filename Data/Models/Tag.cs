using codesome.Data.Courses;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace codesome.Data.Models
{
    [Table("Tags")]
    public class Tag : Base
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; } = "";
        public ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}
