using MFF.DTO.BaseEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MFF.DTO.Entities.SmartLab
{
    public class LenhSanXuatImport : IEntity
    {
        [Key, Column(Order = 1), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
        public DateTime? PLANNED_START_DATE { get; set; }
        public DateTime? PLANNED_COMPLETION_DATE { get; set; }
        public DateTime? RELEASED_DATE { get; set; }
        public DateTime? ACTUAL_COMPLETION_DATE { get; set; }
        public DateTime? CLOSED_DATE { get; set; }
        [StringLength(240)]
        public string ITEM_NUMBER { get; set; }
        [StringLength(240)]
        public string ITEM_NAME { get; set; }
        [StringLength(50)]
        public string UOM_CODE { get; set; }
        [StringLength(150)]
        public string OPERATION_CODE { get; set; }
        public long OPERATION_SEQ_NUMBER { get; set; }
        public string CATEGORY { get; set; }
        public string CATEGORY_NAME { get; set; }
        public ICollection<LenhSanXuatExport> LenhSanXuatExport { get; set; }
    }
    public class ThongTinTieuHaoImport : IEntity
    {
        [Key]
        public int Id { get; set; }
        public long TRANSACTION_ID { get; set; }
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
        public double TRANSACTION_QTY { get; set; }
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
        public string WO_SUB_TYPE { get; set; }
        public string CATEGORY { get; set; }
        public string REWORK_FLAG { get; set; }
        public string BOM_FLAG { get; set; }
        public string CATEGORY_NAME { get; set; }
    }

    #region ERP post
    public class LenhSanXuatExport : IEntity
    {
        [Key, Column(Order = 1), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public long OPERATION_SEQ_NUMBER { get; set; }
        public string OPERATION_CODE { get; set; }
        public string Status { get; set; }
        public string EventType { get; set; } = "WIP";
        public string Inline { get; set; } = "N";
        public string InspectedBy { get; set; } = "impl.kpmg";
        // UTC +0
        public DateTime InspectionDate { get; set; }
        public string OrganizationCode { get; set; }
        // Ten lenh San Xuat
        public string WorkOrderNumber { get; set; }
        public string WoOperationCode { get; set; }
        public string OperationSequenceNumber { get; set; }
        public long QuantityRequested { get; set; }
        public string DispatchStatus { get; set; } = "Ready";
        public string ItemNumber { get; set; }
        public string LotNumber { get; set; }
        public long  SampleId { get; set; }
        public long IpEventId { get; set; }
        public string SampleNumber { get; set; }
        public long SampleEventDispositionId { get; set; }
        public long IpEventDispositionId { get; set; }
        public long SampleResultId { get; set; }
        public long ObjectVersionNumber { get; set; }
        public int Quantity { get; set; } = 0;
        public string DispositionStatus { get; set; }
        public long CharacteristicId { get; set; }
        public int SampleResultObjectVersionNumber { get; set; }
        public int SampleResultQuantity { get; set; }
        public long ResultValueNumber { get; set; }
        public string ResultValueChar { get; set; }
        public DateTime? ResultValueDate { get; set; }
        public string UOMCode { get; set; }
        // Bước nhảy mỗi item là 10 increase 10
        public long UserSequence { get; set; }
        public string CharacteristicName { get; set; }

        public DateTime SaveDate { get; set; }
        public virtual LenhSanXuatImport LenhSanXuatImport { get; set; }
        public int CauHinhBangId { get; set; }
        public long MaKhoa { get; set; }

    }
    public class Sample
    {
        public string SampleNumber { get; set; }
        public SampleDisposition SampleDispositions { get; set; }
    }
    public class SampleDisposition
    {
        public virtual List<SamepleResult> SamepleResults { get; set; }
    }
    public class SamepleResult
    {
        public long UserSequence { get; set; }
        public string CharacteristicName { get; set; }
        public long ResultValueNumber { get; set; }
        public string ResultValueChar { get; set; }
        public string ResultValueDate { get; set; }
        public DateTime InspectionDate { get; set; }

    }
    #endregion
    public class ThongTinTieuHaoExport : IEntity
    {
        [Key]
        public int Id { get; set; }
        public long TRANSACTION_ID { get; set; }
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
