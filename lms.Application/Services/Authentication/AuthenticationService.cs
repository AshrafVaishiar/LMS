using lms.Application.Common.Interfaces.Authentication;
using lms.Application.Common.Interfaces.Persistence;
using lms.Domain.Entities;

namespace lms.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }
    public AuthenticationResult Login(string Email, string Password)
    {
        // check if user already exists
        if(_userRepository.GetUserByEmail(Email) is not User user) {
            throw new Exception("User with given email does not exist.");
        }

        // validate password
        if(user.Password != Password) {
            throw new Exception("Invalid password.");
        }

        // create Jwt Token
        var token = _jwtTokenGenerator.GenerateToken(user);
        return new AuthenticationResult(user, token);
    }

    public AuthenticationResult Register(string UserName, string UserType, string Email, string Password)
    {
        // check if user already exists
        if (_userRepository.GetUserByEmail(Email) is not null)
        {
            throw new Exception("User with given email already exist.");
        }

        // create new user (generate unique ID) & Persist to DB
        var user = new User
        {
            UserName = UserName,
            UserType = UserType,
            Email = Email,
            Password = Password
        };

        _userRepository.Add(user);

        // create JWT Token
        var token = _jwtTokenGenerator.GenerateToken(user);
        return new AuthenticationResult(user, token);
    }
}