using AutoMapper;
using MFF.DTO.Entities;
using MFF.Infrastructure.Models;

namespace MFF.Infrastructure.Mapping
{
    public class ContactProfile : Profile, IMappingProfile
    {
        public ContactProfile()
        {
            CreateMap<ContactMessage, ContactResponseModel>();
            CreateMap<ContactFormModel, ContactMessage>();
            CreateMap<ContactFormModel, ContactFormPassModel>();
        }
    }
}
