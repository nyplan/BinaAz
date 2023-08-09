using AutoMapper;
using BinaAz.Application.DTOs.Item;
using BinaAz.Application.DTOs.Item.AddItem;
using BinaAz.Domain.Entities.TPH;
using BinaAz.Domain.Entities.TPH.Base;
using Object = BinaAz.Domain.Entities.TPH.Object;

namespace BinaAz.Application.Mappers;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<Item, ItemToListDto>()
            .ForMember(dest => dest.City, src => src.MapFrom(x => x.City!.Name))
            .ForPath(dest => dest.ImageUrls, src => src.MapFrom(x => x.ImageUrls.Select(s => s.Replace("\\", "/"))));

        CreateMap<AddGarageRentDto, Garage>();
        CreateMap<AddGardenHouseRentDto, GardenHouse>();
        CreateMap<AddGroundRentDto, Ground>();
        CreateMap<AddNewBuildingRentDto, NewBuilding>();
        CreateMap<AddObjectRentDto, Object>();
        CreateMap<AddOfficeRentDto, Office>();
        CreateMap<AddOldBuildingRentDto, OldBuilding>();

        CreateMap<AddGarageSaleDto, Garage>();
        CreateMap<AddGardenHouseSaleDto, GardenHouse>();
        CreateMap<AddGroundSaleDto, Ground>();
        CreateMap<AddNewBuildingSaleDto, NewBuilding>();
        CreateMap<AddObjectSaleDto, Object>();
        CreateMap<AddOfficeSaleDto, Office>();
        CreateMap<AddOldBuildingSaleDto, OldBuilding>();
    }
}