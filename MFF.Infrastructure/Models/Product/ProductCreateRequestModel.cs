namespace MFF.Infrastructure.Models
{
    public class ProductPublishRequestModel: ProductBase
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public string StateId { get; set; }
        public string State { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public bool? IsPublish { get; set; }

    }
}
