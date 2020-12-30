using AutoMapper;
using MFF.DTO.BaseEntities;
using MFF.Infrastructure.Models;
using System.Linq;

namespace MFF.Infrastructure.Mapping
{
    public class UserProfile : Profile, IMappingProfile
    {
        public UserProfile()
        {
            CreateMap<User, UserItemModel>()
                .ForMember(x => x.RoleCombine, opt => opt.MapFrom(x => (x.UserRoles == null || x.UserRoles.Count == 0) ? string.Empty : string.Join(",", x.UserRoles.Select(z => z.Role.Name))));
            CreateMap<User, UserDetailModel>();
            CreateMap<UserAddModel, User>();
            CreateMap<UserUpdateModel, User>();

            CreateMap<ProfileUpdateModel, User>();
        }
    }
}
