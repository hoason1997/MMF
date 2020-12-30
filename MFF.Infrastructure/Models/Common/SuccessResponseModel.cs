namespace MFF.Infrastructure.Models
{
    public class SuccessResponseModel<T> : BaseResponseModel
    {
        public T Data { get; set; }
    }
}
