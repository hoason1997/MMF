using AutoMapper;
using MFF.DTO.Entities.SmartLab;
using MFF.Infrastructure.Models;

namespace MFF.Infrastructure.Mapping
{
    public  class BanCanMiaProfile:Profile, IMappingProfile
    {
        public BanCanMiaProfile()
        {
            CreateMap<BanCanMia, BanCanMiaModel>().ReverseMap();

            CreateMap<BanCanMia, BanCanMiaDetailModel>().ReverseMap()
               .ForMember(x => x.CreatedBy, opt => opt.Ignore())
               .ForMember(x => x.CreatedTime, opt => opt.Ignore())
               .ForMember(x => x.UpdatedBy, opt => opt.Ignore())
               .ForMember(x => x.UpdatedTime, opt => opt.Ignore());
        }
    }
}
