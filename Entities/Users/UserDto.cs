using Core.BaseEntityModel;

namespace Entities.Users;

public class UserDto 
{
    public Guid Id { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public string UserName { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
}