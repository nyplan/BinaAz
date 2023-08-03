using System.ComponentModel.DataAnnotations.Schema;
using BinaAz.Domain.Entities.Common;
using BinaAz.Domain.Entities.TPH;

namespace BinaAz.Domain.Entities;

public class Image : BaseEntity
{
    public string FileName { get; set; } = null!;
    public string Path { get; set; } = null!;
    public string Storage { get; set; } = null!;
    public ICollection<Item>? Items { get; set; }
    
    [NotMapped]
    public override DateTime? UpdatedAt { get => base.UpdatedAt; set => base.UpdatedAt = value; }
    [NotMapped]
    public override DateTime? DeletedAt { get => base.DeletedAt; set => base.DeletedAt = value; }
}