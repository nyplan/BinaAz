using BinaAz.Domain.Entities.Common;

namespace BinaAz.Domain.Entities;

public class Agency : BaseEntity
{
    public string CompanyName { get; set; }
    public string RelevantPerson { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
}