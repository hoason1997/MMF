using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MFF.Infrastructure.Models
{
    public class EffectiveModel
    {
        public EffectiveModel()
        {
            Items = new List<EffectiveItemModel>();
        }
        public string Background { get; set; }
        public List<EffectiveItemModel> Items { get; set; }
    }
    public class EffectiveItemModel
    {
        public string ItemIconImage { get; set; }
        public int NumberCount { get; set; }
        public string ItemDescription { get; set; }
    }
}
