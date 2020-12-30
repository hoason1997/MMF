using System;

namespace MFF.Infrastructure.Models
{
    public class FeedbackModel
    {
        public string CustomerFullName { get; set; }
        public string CustomerAvatarUrl { get; set; }
        public string Title { get; set; }
        public DateTime FeedbackDate { get; set; }
        public string Content { get; set; }
        public int RateType { get; set; }
    }
}
