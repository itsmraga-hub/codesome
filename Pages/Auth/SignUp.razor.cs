using codesome.Authentication;
using codesome.Data.Models;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

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
            public DateTime DateOfBirth { get; set; }
            public int Age { get; set; }

            [Required]            
            [StringLength(20, ErrorMessage = "Role is Required")]
            public string Role { get; set; } = "Default";

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
            user.DateOfBirth = model.DateOfBirth;
            user.age = DateTime.Now.Year - model.DateOfBirth.Year;
            user.Role = model.Role;
            if (model.Password == model.Password2)
            {
                user.PasswordHash = model.Password;
                var res = await _userService.CreateUserAsync(user);
                // await LocalStorage.SetItemAsync("uid", res.Id);
                if (res.IsAuthenticated)
                {                    
                    var customAuthenticationStateProvider = (CustomAuthenticationStateProvider)authenticationStateProvider;
                    await customAuthenticationStateProvider!.UpdateAuthenticationState(res);
                    
                    NavigationManager.NavigateTo("/", true);
                    // await LocalStorage.SetItemAsync("uid", res.Id);
                    await LocalStorage.SetItemAsync("__id", res.Id);
                }
            }
            else
            {
                await JSRuntime.InvokeVoidAsync("alert", "Passwords do not match");
            }
            
        }
    }
}
