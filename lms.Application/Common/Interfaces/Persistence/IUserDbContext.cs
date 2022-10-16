using lms.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace lms.Infrastructure.Persistence
{
    public interface IUserDbContext
    {
        DbSet<User> Users { get; set; }
    }
}