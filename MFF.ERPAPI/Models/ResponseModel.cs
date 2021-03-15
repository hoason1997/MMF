using System;
using System.Collections.Generic;

namespace MFF.ERPAPI.Models
{
    public class ResponseModel
    {
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
        public Sample Sameple { get; set; }
    }
    public class Sample
    {
        public string SampleNumber { get; set; }
        public SampleDisposition SampleDispositions { get; set; }
    }
    public class SampleDisposition
    {
        public virtual List<SampleResult> SampleResults { get; set; }
    }
    public class SampleResult
    {
        public long UserSequence { get; set; }
        public string CharacteristicName { get; set; }
        public long ResultValueNumber { get; set; }
        public string ResultValueChar { get; set; }
        public string ResultValueDate { get; set; }
        public DateTime InspectionDate { get; set; }

    }
}
