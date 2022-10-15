namespace lms.Application.Services.Authentication;

public interface IAuthenticationService{
    AuthenticationResult Login(string Email, string Password);

    AuthenticationResult Register(string UserName, string UserType, string Email, string Password);
}