using Refit;
using System.Collections.Generic;

namespace MFF.Infrastructure.Models
{
    public class ProductRequestModel
    {
        public string Keyword { get; set; }
        public string OrderCol { get; set; }
        public string StateName { get; set; }
        public bool? IsPublish { get; set; }
        [Query(CollectionFormat.Multi)]
        public List<string> ProductPortalIds { get; set; }
        public bool? IsActive { get; set; }
        public string OrderType { get; set; }
        public int? Page { get; set; }
        public int? Size { get; set; }
    }
}
