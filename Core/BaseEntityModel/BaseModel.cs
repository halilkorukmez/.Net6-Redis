using System.ComponentModel.DataAnnotations;

namespace Core.BaseEntityModel;

public abstract class BaseModel : IBaseModel
{
    [Key]
    public Guid Id { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedDate { get; set; }

    public BaseModel()
    {
        this.Id = Guid.NewGuid();
        this.IsActive = true;
        this.CreatedDate = DateTime.Now;
    }
}