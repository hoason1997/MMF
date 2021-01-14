using System;
using System.ComponentModel.DataAnnotations;

namespace MFF.ERPAPI.Entities
{
    public class LenhSanXuatERP 
    {
        [Key]
        public int Id { get; set; }
    //    [Column(TypeName = "decimal(18, 2)")]
        public long WORK_ORDER_ID { get; set; }
        [StringLength(240)]
        public string BUSINESS_UNIT_NAME { get; set; }
        public long BUSINESS_UNIT_ID { get; set; }
        [StringLength(30)]
        public string ORGANIZATION_CODE { get; set; }
        [StringLength(240)]
        public string ORGANIZATION_NAME { get; set; }
        [StringLength(120)]
        public string WORK_ORDER_NUMBER { get; set; }
        [StringLength(50)]
        public string WO_TYPE { get; set; }
        [StringLength(100)]
        public string WO_STATUS_NAME { get; set; }
        public DateTime PLANNED_START_DATE { get; set; }
        public DateTime PLANNED_COMPLETION_DATE { get; set; }
        public DateTime RELEASED_DATE { get; set; }
        public DateTime ACTUAL_COMPLETION_DATE { get; set; }
        public DateTime CLOSED_DATE { get; set; }
        [StringLength(240)]
        public string ITEM_NUMBER { get; set; }
        [StringLength(240)]
        public string ITEM_NAME { get; set; }
        [StringLength(50)]
        public string UOM_CODE { get; set; }    
    }
    public class ThongTinTieuHao 
    {
        [Key]
        public int Id { get; set; }
        public long TRANSACTION_ID { get; set; }
        [StringLength(240)]
        public string BUSINESS_UNIT_NAME { get; set; }
        public long BUSINESS_UNIT_ID { get; set; }
        [StringLength(30)]
        public string ORGANIZATION_CODE { get; set; }
        [StringLength(240)]
        public string ORGANIZATION_NAME { get; set; }
        [StringLength(50)]
        public string WORK_ORDER_NUMBER { get; set; }
        [StringLength(240)]
        public string ITEM_NUMBER { get; set; }
        [StringLength(240)]
        public string ITEM_NAME { get; set; }
        [StringLength(240)]
        public string TRANSACTION_TYPE { get; set; }
        public int TRANSACTION_QTY { get; set; } 
        [StringLength(50)]
        public string UOM_CODE { get; set; }
        public DateTime TRANSACTION_DATE { get; set; }
        [StringLength(50)]
        public string LOT_NUMBER { get; set; }
        [StringLength(120)]
        public string POL_TYPE { get; set; }
        [StringLength(18)]
        public string SUB_INV_CODE { get; set; }
        [StringLength(40)]
        public string LOCATOR { get; set; }      
    }
}
