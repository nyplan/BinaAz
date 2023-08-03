using AutoMapper;
using BinaAz.Application.DTOs.User;
using BinaAz.Domain.Entities;

namespace BinaAz.Application.Mappers;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<User, CreateUser>()
            .ForMember(src => src.Email, dest => dest.MapFrom(x => x.Email));
    }
}