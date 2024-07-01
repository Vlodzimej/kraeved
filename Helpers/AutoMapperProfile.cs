using AutoMapper;
using KraevedAPI.Models;

namespace KraevedAPI.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<GeoObject, GeoObjectBrief>()
            .ForMember(
                dest => dest.Type,
                src => src.MapFrom(
                    item => item.Type != null ? item.Type.Name : "UNKNOWN"
                )
            );
            CreateMap<HistoricalEvent, HistoricalEventBrief>();
            CreateMap<User, UserOutDto>()
                .ForMember(
                dest => dest.Role,
                src => src.MapFrom(
                    item => item.Role.Name != null ? item.Role.Name : "UNKNOWN"
                )
            );
        }
    }
}
