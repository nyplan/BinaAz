using System.ComponentModel.DataAnnotations.Schema;
using BinaAz.Domain.Entities.Common;
using BinaAz.Domain.Entities.TPH.Base;

namespace BinaAz.Domain.Entities;

public class Image : BaseEntity
{
    public Guid ItemId { get; set; }
    public Item? Item { get; set; }
    public int ItemNumber { get; set; }
    public string FileName { get; set; } = null!;
    public string Path { get; set; } = null!;

    public ICollection<User>? Users { get; set; }
    
    [NotMapped]
    public override DateTime? UpdatedAt { get => base.UpdatedAt; set => base.UpdatedAt = value; }
    [NotMapped]
    public override DateTime? DeletedAt { get => base.DeletedAt; set => base.DeletedAt = value; }
}