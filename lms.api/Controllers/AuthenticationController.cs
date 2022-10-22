using ErrorOr;
using lms.Application.Services.Authentication;
using lms.Contracts.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace lms.api.Controllers;

//[EnableCors("corspolicy")]
[ApiController]
[Route("/")]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    protected IActionResult Problem(List<Error> errors)
    {
        var firstError = errors[0];
        var statusCode = firstError.Type switch
        {
            ErrorType.Conflict => StatusCodes.Status409Conflict,
            ErrorType.Validation => StatusCodes.Status400BadRequest,
            ErrorType.NotFound => StatusCodes.Status404NotFound,
            _ => StatusCodes.Status500InternalServerError
        };

        return Problem(statusCode: statusCode, title: firstError.Description);
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {
        var authResult = _authenticationService.Register(request.UserName, request.UserType, request.Email, request.Password);
        return authResult.Match
            (authResult => Ok(ReturnAuthenticationResponse(authResult)),
            errors => Problem(errors));
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        var authResult = _authenticationService.Login(request.Email, request.Password);
        return authResult.Match
            (authResult => Ok(ReturnAuthenticationResponse(authResult)),
            errors => Problem(errors));

    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok("lms web api : you hit the sample Get host/");
    }

    private static AuthenticationResponse ReturnAuthenticationResponse(AuthenticationResult authResult)
    {
        return new AuthenticationResponse(
            authResult.user.Id,
            authResult.user.UserName,
            authResult.user.Email,
            authResult.Token);
    }
}