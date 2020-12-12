using AutoMapper;
using MFF.DTO.Entities;
using MFF.Infrastructure.Models;

namespace MFF.Infrastructure.Mapping
{
    public class ProductProfile : Profile, IMappingProfile
    {
        public ProductProfile()
        {
            CreateMap<ProductPublishRequestModel, Product>()
            .ForMember(x => x.ProductCode, opt => opt.MapFrom(x => x.Code))
            .ForMember(x => x.ProductName, opt => opt.MapFrom(x => x.Name))
            .ForMember(x => x.CreatedBy, opt => opt.Ignore())
            .ForMember(x => x.CreatedTime, opt => opt.Ignore());
            CreateMap<Product, ProductPublishRequestModel>();

            CreateMap<ProductBackOfficeModel, Product>()
            .ForMember(x => x.ProductCode, opt => opt.MapFrom(x => x.Code))
            .ForMember(x => x.ProductName, opt => opt.MapFrom(x => x.Name));

        }
    }
}
