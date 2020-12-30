using System;
using System.Collections.Generic;
using System.Text;

namespace MFF.Infrastructure.Models
{
    [Serializable]
    public class GoogleAnalyticsOption: GoogleOption
    {
        public string ViewId { get; set; }
        public int PageSize { get; set; }
    }
}
