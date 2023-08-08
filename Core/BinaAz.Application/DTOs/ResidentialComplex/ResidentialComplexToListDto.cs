using BinaAz.Application.DTOs.Image;

namespace BinaAz.Application.DTOs.ResidentialComplex;

public class ResidentialComplexToListDto
{
    public ImageToListDto Image { get; set; } = new();
    public int MinPrice { get; set; }
    public string Name { get; set; } = null!;
    public string Address { get; set; } = null!;
    public int HandOverYear { get; set; }
}