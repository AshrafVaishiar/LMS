using lms.Domain.Entities;

namespace lms.Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
    User? GetUserByEmail(string Email);
    void Add(User user);
}