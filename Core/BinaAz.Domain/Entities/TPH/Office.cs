using BinaAz.Domain.Entities.TPH.Base;
using BinaAz.Domain.Enums;

namespace BinaAz.Domain.Entities.TPH;

public class Office : Item
{
    public TypeOfOffice? TypeOfOffice { get; set; }
}