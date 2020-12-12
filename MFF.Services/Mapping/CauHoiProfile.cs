using AutoMapper;
using MFF.DTO.Entities.NHCH;
using MFF.Infrastructure.Models;

namespace MFF.Infrastructure.Mapping
{
    public  class CauHoiProfile:Profile, IMappingProfile
    {
        public CauHoiProfile()
        {
            CreateMap<CauHoi, CauHoiModel>().ReverseMap()
                .ForMember(x => x.CreatedBy, opt => opt.Ignore())
                .ForMember(x => x.CreatedTime, opt => opt.Ignore())
                .ForMember(x => x.UpdatedBy, opt => opt.Ignore())
                .ForMember(x => x.UpdatedTime, opt => opt.Ignore());

            CreateMap<CauHoi, CauHoiDetailModel>().ReverseMap()
               .ForMember(x => x.CreatedBy, opt => opt.Ignore())
               .ForMember(x => x.CreatedTime, opt => opt.Ignore())
               .ForMember(x => x.UpdatedBy, opt => opt.Ignore())
               .ForMember(x => x.UpdatedTime, opt => opt.Ignore());
        }
    }
}
