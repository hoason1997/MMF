using System;

namespace MFF.DTO.BaseEntities
{
    public class MFFItem : IDTO<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
