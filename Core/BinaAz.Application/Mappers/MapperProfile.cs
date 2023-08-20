using AutoMapper;
using BinaAz.Application.DTOs.Item;
using BinaAz.Application.DTOs.Item.AddUpdateItem;
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

        CreateMap<GarageRentDto, Garage>();
        CreateMap<GardenHouseRentDto, GardenHouse>();
        CreateMap<GroundRentDto, Ground>();
        CreateMap<NewBuildingRentDto, NewBuilding>();
        CreateMap<ObjectRentDto, Object>();
        CreateMap<OfficeRentDto, Office>();
        CreateMap<OldBuildingRentDto, OldBuilding>();

        CreateMap<GarageSaleDto, Garage>();
        CreateMap<GardenHouseSaleDto, GardenHouse>();
        CreateMap<GroundSaleDto, Ground>();
        CreateMap<NewBuildingSaleDto, NewBuilding>();
        CreateMap<ObjectSaleDto, Object>();
        CreateMap<OfficeSaleDto, Office>();
        CreateMap<OldBuildingSaleDto, OldBuilding>();
    }
}