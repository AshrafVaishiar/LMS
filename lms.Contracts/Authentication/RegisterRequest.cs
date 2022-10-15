namespace lms.Contracts.Authentication;

public record RegisterRequest(
    string UserName,
    string UserType,
    string Email,
    string Password
);