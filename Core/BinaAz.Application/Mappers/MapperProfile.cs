using AutoMapper;
using BinaAz.Application.DTOs.Item.AddItem;
using BinaAz.Domain.Entities.TPH;
using Object = BinaAz.Domain.Entities.TPH.Object;

namespace BinaAz.Application.Mappers;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<AddGarageRentDto, Garage>()
            .ForMember(dest => dest.Images, src => src.Ignore());
        CreateMap<AddGardenHouseRentDto, GardenHouse>()
            .ForMember(dest => dest.Images, src => src.Ignore());
        CreateMap<AddGroundRentDto, Ground>()
            .ForMember(dest => dest.Images, src => src.Ignore());
        CreateMap<AddNewBuildingRentDto, NewBuilding>()
            .ForMember(dest => dest.Images, src => src.Ignore());
        CreateMap<AddObjectRentDto, Object>()
            .ForMember(dest => dest.Images, src => src.Ignore());
        CreateMap<AddOfficeRentDto, Office>()
            .ForMember(dest => dest.Images, src => src.Ignore());
        CreateMap<AddOldBuildingRentDto, OldBuilding>()
            .ForMember(dest => dest.Images, src => src.Ignore());
        
        CreateMap<AddGarageSaleDto, Garage>()
            .ForMember(dest => dest.Images, src => src.Ignore());
        CreateMap<AddGardenHouseSaleDto, GardenHouse>()
            .ForMember(dest => dest.Images, src => src.Ignore());
        CreateMap<AddGroundSaleDto, Ground>()
            .ForMember(dest => dest.Images, src => src.Ignore());
        CreateMap<AddNewBuildingSaleDto, NewBuilding>()
            .ForMember(dest => dest.Images, src => src.Ignore());
        CreateMap<AddObjectSaleDto, Object>()
            .ForMember(dest => dest.Images, src => src.Ignore());
        CreateMap<AddOfficeSaleDto, Office>()
            .ForMember(dest => dest.Images, src => src.Ignore());
        CreateMap<AddOldBuildingSaleDto, OldBuilding>()
            .ForMember(dest => dest.Images, src => src.Ignore());
    }
}