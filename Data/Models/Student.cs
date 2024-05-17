using codesome.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace codesome.Data.Courses
{
    [Table("Students")]
    public class Student : User
    {
    }
}