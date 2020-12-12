using AutoMapper;
using MFF.DTO.Entities;
using MFF.Infrastructure.Models;

namespace MFF.Infrastructure.Mapping
{
    public class BannerProfile : Profile, IMappingProfile
    {
        public BannerProfile()
        {
            CreateMap<Banner, BannerModel>();
        }
    }
}
