using lms.Domain.Entities;
//
namespace lms.Application.Services.Authentication;
public record AuthenticationResult(
    User user
    //string Token
);