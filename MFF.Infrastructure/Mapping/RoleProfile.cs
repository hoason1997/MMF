using AutoMapper;
using MFF.DTO.BaseEntities;
using MFF.Infrastructure.Models;

namespace MFF.Infrastructure.Mapping
{
    public class RoleProfile : Profile, IMappingProfile
    {
        public RoleProfile()
        {
            CreateMap<Role, RoleItemModel>();
        }
    }
}
