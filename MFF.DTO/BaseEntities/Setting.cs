namespace MFF.DTO.BaseEntities
{
    public class Setting : GuIdEntity
    {
        public string Keys { get; set; }
        public string Values { get; set; }
        public string GroupId { get; set; }
    }
}
