using AutoMapper;
using GuestDomain.Dtos;
using GuestDomain.Entities;

namespace GuestDataAccess.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<GuestEntity, GuestDto>();
        }
    }
}
