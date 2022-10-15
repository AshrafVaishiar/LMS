using lms.Application.Common.Interfaces.Persistence;
using lms.Domain.Entities;

namespace lms.Infrastructure.Persistence;

public class UserRepository : IUserRepository
{
    private static readonly List<User> _users = new();
    public void Add(User user)
    {
        _users.Add(user);
    }

    public User? GetUserByEmail(string Email)
    {
       return  _users.SingleOrDefault(u => u.Email ==  Email);
    }
}