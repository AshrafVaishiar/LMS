using lms.Application.Services.Authentication;
using lms.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace lms.api.Controllers;

[ApiController]
[Route("company")]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {
        var authResult = _authenticationService.Register(request.UserName, request.UserType, request.Email, request.Password);
        var response = new AuthenticationResponse(authResult.user.Id, authResult.user.UserName, authResult.user.Email, authResult.Token);
        return Ok(response);
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        var authResult = _authenticationService.Login(request.Email, request.Password);
        var response = new AuthenticationResponse(authResult.user.Id, authResult.user.UserName, authResult.user.Email, authResult.Token);
        return Ok(response);
    }
}