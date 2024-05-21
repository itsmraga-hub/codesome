﻿using codesome.Data.Courses;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace codesome.Data.Models
{
    [Table("Lessons")]
    public class Lesson : Base
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public string VideoUrl { get; set; } = "";
        public int Duration { get; set; }
        public int Order { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; } = null!;
    }
}
