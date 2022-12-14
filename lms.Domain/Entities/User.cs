using MongoDB.Bson.Serialization.Attributes;

namespace lms.Domain.Entities;

public class User {
    public Guid Id {get; set;} = Guid.NewGuid();

    public string UserName { get; set; } = null!;

    public string UserType { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;
}