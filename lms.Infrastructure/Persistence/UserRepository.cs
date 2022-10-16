using lms.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace lms.Infrastructure.Persistence;

public class UserRepository : IUserRepository
{
    private readonly UserDbContext _userDbContext;
    public UserRepository(UserDbContext userDbContext)
    {
        _userDbContext = userDbContext;
    }
    
    public async Task Add(User user)
    {
        await _userDbContext.Users.AddAsync(user);
        await _userDbContext.SaveChangesAsync();
    }

    public User? GetUserByEmail(string Email)
    {
        return _userDbContext.Users.SingleOrDefault(u => u.Email == Email);
    }
}