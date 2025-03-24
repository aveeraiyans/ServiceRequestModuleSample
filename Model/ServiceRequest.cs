using System.Text.Json.Serialization;

namespace ServiceRequestModule.Model
{
    public class ServiceRequest
    {
        public Guid? id { get; set; }
        public string? buildingCode { get; set; }
        public string? description { get; set; }
        public _currentStatus currentStatus { get; set; }
        public string? createdBy { get; set; }
        public DateTime? createdDate { get; set; }
        public string? lastModifiedBy { get; set; } = string.Empty;
        public DateTime? lastModifiedDate { get; set; }
    }

    public enum _currentStatus
    {
        NotApplicable,
        Created,
        InProgress,
        Complete,
        Canceled
    }
}
