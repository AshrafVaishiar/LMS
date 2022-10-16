using lms.Domain.Entities;

namespace lms.Infrastructure.Persistence
{
    public interface IUserRepository
    {
        Task Add(User user);
        User? GetUserByEmail(string Email);
    }
}