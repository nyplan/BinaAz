namespace BinaAz.Domain.Entities;

public class Agency : User
{
    public string CompanyName { get; set; } = null!;
    public string RelevantPerson { get; set; } = null!;
    public bool IsResidentialComplex { get; set; }
}