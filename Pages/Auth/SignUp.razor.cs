using codesome.Data.Models;
using Microsoft.AspNetCore.Components.Forms;
using System.ComponentModel.DataAnnotations;

namespace codesome.Pages.Auth
{
    public partial class SignUp
    {
        RegisterAccountForm model = new RegisterAccountForm();
        bool success;

        public class RegisterAccountForm
        {
            [Required]
            [StringLength(8, ErrorMessage = "Name length can't be more than 8.")]
            public string FirstName { get; set; } = "";

            [Required]
            [StringLength(8, ErrorMessage = "Name length can't be more than 8.")]
            public string LastName { get; set; } = "";

            [Required]
            [StringLength(8, ErrorMessage = "Name length can't be more than 8.")]
            public string Username { get; set; } = "";

            [Required]
            [StringLength(12, ErrorMessage = "Phone length can't be more than 12.")]
            public string PhoneNumber { get; set; } = "";

            [Required]
            public int Age { get; set; }

            [Required]
            [EmailAddress]
            public string Email { get; set; } = "";

            [Required]
            [StringLength(30, ErrorMessage = "Password must be at least 8 characters long.", MinimumLength = 8)]
            public string Password { get; set; } = "";

            [Required]
            [Compare(nameof(Password))]
            public string Password2 { get; set; } = "";

        }

        private void OnValidSubmit(EditContext context)
        {
            User user = new User
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email
            };
            user.PhoneNumber = model.PhoneNumber;
            user.PhoneNumberConfirmed = true;
            user.UserName = model.Username;
            user.EmailConfirmed = true;
            user.age = model.Age;
            success = true;
            StateHasChanged();
        }
    }
}
