using codesome.Authentication;
using codesome.Data.Models;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using System.ComponentModel.DataAnnotations;

namespace codesome.Pages.Auth
{
    public partial class SignUp
    {
        RegisterAccountForm model = new RegisterAccountForm();

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

        private async void OnValidSubmit(EditContext context)
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
            if (model.Password == model.Password2)
            {
                user.PasswordHash = model.Password;
                var res = await _userService.CreateUserAsync(user);
                if (res.IsAuthenticated)
                {
                    var customAuthenticationStateProvider = (CustomAuthenticationStateProvider)authenticationStateProvider;
                    await customAuthenticationStateProvider!.UpdateAuthenticationState(res);
                    await LocalStorage.SetItemAsync("uid", res.Id);
                    NavigationManager.NavigateTo("/", true);
                }
            }
            else
            {
                await JSRuntime.InvokeVoidAsync("alert", "Passwords do not match");
            }
            
        }
    }
}
