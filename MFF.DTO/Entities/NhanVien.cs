using System;
using System.ComponentModel.DataAnnotations;

namespace MFF.DTO.Entities
{
    public class NhanVien //:BaseEntities.Entity
    {
        public string TenNhanVien { get; set; }
        [Key]
        public int NhanVien_Id { get; set; }
     //   public double? TrongSo { get; set; }
      //  public DateTime? CreateDate { get; set; }
      //  public bool? Status { get; set; }
    }
}
