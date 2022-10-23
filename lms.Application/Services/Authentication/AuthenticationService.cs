using lms.api.Common.Errors;
using ErrorOr;
//using lms.Application.Common.Interfaces.Authentication;
using lms.Domain.Entities;
using lms.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace lms.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    //private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationService(/*IJwtTokenGenerator jwtTokenGenerator, */IUserRepository userRepository)
    {
        //_jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }
    public ErrorOr<AuthenticationResult> Login(string Email, string Password)
    {
        // check if user already exists
        if(_userRepository.GetUserByEmail(Email) is not User user) {
            return Errors.Authentication.InvalidCredentials;
        }

        // validate password
        if(user.Password != Password) {
            return Errors.Authentication.InvalidCredentials;
        }

        // create Jwt Token
        //var token = _jwtTokenGenerator.GenerateToken(user);
        return new AuthenticationResult(user);
    }

    public ErrorOr<AuthenticationResult> Register(string UserName, string UserType, string Email, string Password)
    {
        // check if user already exists
        if (_userRepository.GetUserByEmail(Email) is not null)
        {
            return Errors.User.DuplicateEmail;
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
        //var token = _jwtTokenGenerator.GenerateToken(user);
        return new AuthenticationResult(user);
    }
}