using codesome.Authentication;
using codesome.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace codesome.Data.Services.Users
{
    public class UserService : IUserService
    {
        private readonly codesomeContext _context;
        private readonly IPasswordHasher<IdentityUser> _passwordHasher;
        private readonly ILogger<UserService> _logger;

        public UserService(codesomeContext context, IPasswordHasher<IdentityUser> passwordHasher, ILogger<UserService> logger)
        {
            _context = context;
            _passwordHasher = passwordHasher;
            _logger = logger;
        }

        public Task<UserSession> CreateUserAsync(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            var hashedPassword = _passwordHasher.HashPassword(user, user.PasswordHash);
            user.SecurityStamp = Guid.NewGuid().ToString();
            user.Id = Guid.NewGuid().ToString();
            user.PasswordHash = hashedPassword;
            _context.User.Add(user);
            _context.SaveChanges();
            var userSession = new UserSession
            {
                Id = user.Id,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Username = user.UserName
            };
            return Task.FromResult(userSession);
        }

        public Task<UserSession> AuthenticateUser(string email, string password)
        {
            var user = _context.User.FirstOrDefault(u => u.Email == email);
            if (user == null)
            {
                throw new InvalidOperationException("User not found.");
            }

            var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, password);
            if (result == PasswordVerificationResult.Failed)
            {
                throw new InvalidOperationException("Invalid password.");
            }
            var userSession = new UserSession
            {
                Id = user.Id,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Username = user.UserName
            };

            return Task.FromResult(userSession);
        }

    }
}
