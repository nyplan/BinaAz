using BinaAz.Application.DTOs.ResidentialComplex;

namespace BinaAz.Application.Features.Queries.Items.ResidentialComplexItems;

public class ResidentialComplexItemsQueryResponse
{
    public List<ResidentialComplexToListDto> ResidentialComplexes { get; set; } = new();
}