using AutoMapper;
using RegisterDomain.Dtos;
using RegisterDomain.Entities;

namespace RegisterDataAccess.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RegisterDomain.Entities.RoomType, RoomTypeDto>();
            CreateMap<RegisterDomain.Entities.Room, RoomDto>();
        }
    }
}
