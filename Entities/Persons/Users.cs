using Core.Entities;

namespace Entities.Persons;

public class Users : Entity<int>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}
