using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace codesome.Data.Models
{
    [Table("Users")]
    public class User : IdentityUser
    {
        public int age { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string ProfilePictureUrl { get; set; } = "";
        public UserRole Role { get; set; } = UserRole.Student;
        public string Bio { get; set; } = "";
        public DateTime DateJoined { get; set; }

        // Additional properties or methods can be added here
    }

    public enum UserRole
    {
        Default,
        Student,
        Instructor,
        Admin
    }

}
