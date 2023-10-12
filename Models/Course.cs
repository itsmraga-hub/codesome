using System.ComponentModel.DataAnnotations;

namespace Codesome.Models;

public class Course
{
    public int Id { get; set; }

    public string? Title { get; set; }
    public string Owner { get; set; }
    public double? Price { get; set; }

    public int? StudentsEnrolled { get; set; }
    
    [DataType(DataType.Date)]
    public DateTime StartDate { get; set; }
    
    [DataType(DataType.Date)]
    public DateTime EndDate { get; set; }
    
}