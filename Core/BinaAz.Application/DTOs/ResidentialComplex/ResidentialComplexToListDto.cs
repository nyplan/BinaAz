namespace BinaAz.Application.DTOs.ResidentialComplex;

public class ResidentialComplexToListDto
{
    public string? ImageUrl { get; set; }
    public int MinPrice { get; set; }
    public string Name { get; set; } = null!;
    public string Address { get; set; } = null!;
    public int HandOverYear { get; set; }
}