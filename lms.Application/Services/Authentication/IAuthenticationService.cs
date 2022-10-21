using ErrorOr;

namespace lms.Application.Services.Authentication;

public interface IAuthenticationService{
    ErrorOr<AuthenticationResult> Login(string Email, string Password);

    ErrorOr<AuthenticationResult> Register(string UserName, string UserType, string Email, string Password);
}