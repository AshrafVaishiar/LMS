using lms.Application.Common.Interfaces.Services;

namespace lms.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}