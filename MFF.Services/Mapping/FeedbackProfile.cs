using AutoMapper;

namespace MFF.Infrastructure.Mapping
{
    public class FeedbackProfile : Profile, IMappingProfile
    {
        public FeedbackProfile()
        {
            //CreateMap<FeedbackCreateRequestModel, Feedback>()
            //    .ForMember(x => x.Content, opt => opt.MapFrom(x => x.Feedback))
            //    .ForMember(x => x.CustomerId, opt => opt.MapFrom(x => x.CustomerId))
            //    .ForMember(x => x.CustomerFullName, opt => opt.MapFrom(x => x.FullName))
            //    .ForMember(x => x.CustomerAvatarUrl, opt => opt.MapFrom(x => x.CustomerAvatarUrl))
            //    .ForMember(x => x.Title, opt => opt.MapFrom(x => x.Title))
            //    .ForMember(x => x.WorkOrderNumber, opt => opt.MapFrom(x => x.WorkOrderNumber))
            //    .ForMember(x => x.RateType, opt => opt.MapFrom(x => x.RateType))
            //    .ForMember(x => x.FeedbackDate, opt => opt.MapFrom(x => x.CreatedTime))
            //    .ForMember(x => x.CreatedBy, opt => opt.Ignore())
            //    .ForMember(x => x.UpdatedTime, opt => opt.Ignore());

            //CreateMap<Feedback, FeedbackModel>();
        }
    }
}
