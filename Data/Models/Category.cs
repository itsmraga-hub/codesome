using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using codesome.Data.Courses;

namespace codesome.Data.Models
{
    [Table("Categories")]
    public class Category : Base
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public bool isMainCategory { get; set; } = false;
        public ICollection<Course> Courses { get; set; } = new List<Course>();
        public ICollection<Category> AllCategories { get;} = new List<Category>();

    }
}
