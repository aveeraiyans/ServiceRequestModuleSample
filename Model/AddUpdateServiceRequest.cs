﻿namespace ServiceRequestModule.Model
{
    public class AddUpdateServiceRequest
    {
        public Guid? Id { get; set; }
        public string? BuildingCode { get; set; }
        public string? Description { get; set; }
        public _currentStatus currentStatus { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }
}
