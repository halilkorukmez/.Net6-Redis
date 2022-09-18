using Core.BaseEntityModel;
using Entities.Baskets;

namespace Entities.Users;

public class User : BaseModel
{
    public string UserName { get; set; }
    public string Name { get; set; }
    public string SurName { get; set; }
}