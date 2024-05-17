using codesome.Data.Models;

namespace codesome.Data.Services.Users
{
    public class UsersService
    {
        private readonly codesomeContext _context;

        public UsersService(codesomeContext context)
        {
            _context = context;
        }

        public Task CreateUserAsync(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            _context.User.Add(user);
            _context.SaveChanges();

            return Task.CompletedTask;
        }

    }
}
