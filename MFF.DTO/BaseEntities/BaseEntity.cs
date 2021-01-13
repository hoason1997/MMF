using System;

namespace MFF.DTO.BaseEntities
{
    public interface IBaseEntity : IEntity
    {
        public string Id { get; set; }
        public string TaoBoi { get; set; }
        public DateTime? NgayTao { get; set; }
        public DateTime? NgayCapNhat { get; set; }
        public string CapNhatBoi { get; set; }
    }
    public class BaseEntity: IBaseEntity
    {
        #region base clock
        //public BaseEntity()
        //{
        //    CreatedTime = DateTime.UtcNow;
        //    UpdatedTime = DateTime.UtcNow;
        //}
        //public string CreatedBy { get; set; }
        //public string UpdatedBy { get; set; }
        //public DateTime CreatedTime { get; set; }
        //public DateTime UpdatedTime { get; set; }
        //[Timestamp]
        //public byte[] RowVersion { get; set; }
        #endregion
        public BaseEntity()
        {
            NgayTao = DateTime.UtcNow;
            NgayCapNhat = DateTime.UtcNow;
        }
        public string Id { get; set; }
        public string TaoBoi { get; set; }
        public DateTime? NgayTao { get; set; }
        public DateTime? NgayCapNhat { get; set; }
        public string CapNhatBoi { get; set; }
    }
}
