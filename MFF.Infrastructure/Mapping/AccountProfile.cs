using AutoMapper;
using MFF.DTO.BaseEntities;
using MFF.Infrastructure.Models;

namespace MFF.Infrastructure.Mapping
{
    public class AccountProfile : Profile, IMappingProfile
    {
        public AccountProfile()
        {
            CreateMap<User, UserProfileResponse>();
        }
    }
}
