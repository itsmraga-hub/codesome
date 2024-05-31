using codesome.Authentication;
using codesome.Data.Models;

namespace codesome.Data.Services.Users
{
    public interface IUserService
    {
        Task<UserSession> CreateUserAsync(User user);
        Task<UserSession> AuthenticateUser(string email, string password);
    }
}
