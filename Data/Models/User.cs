using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace codesome.Data.Models
{
    [Table("Users")]
    public class User : IdentityUser
    {
        public int age { get; set; }
        public DateTime DateOfBirth { get; set; } = DateTime.Now.Date;
        public string Role { get; set; } = "Default";
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string ProfilePictureUrl { get; set; } = "";
        public string Bio { get; set; } = "";
        public DateTime DateJoined { get; set; } = DateTime.Now.Date;
    }

    public enum UserRole
    {
        Default,
        Student,
        Instructor,
        Administrator
    }

}
