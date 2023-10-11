using System.ComponentModel.DataAnnotations;

namespace Codesome.Models;

public class Course
{
    public int Id { get; set; }

    public string? Title { get; set; }
    public string Owner { get; set; }
    public decimal? Price { get; set; }

    public int? StudentsEnrolled = 0 { get; set; }
    
    [DataType(DataType.Date)]
    public DateTime StartDate { get; set; }
    [DataType(DataType.Date)]
    public DateTime EndDate { get; set; }
    
}

// public int Id { get; set; }
// public string FirstName { get; set; }
// public string LastName { get; set; }
// public string Email { get; set; }
// public string PhoneNumber { get; set; }
// public string Country { get; set; }
// public string Role { get; set; }
//     
// public string Password { get; set; }
// public string PaypalEmail { get; set; }