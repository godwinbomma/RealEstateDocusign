using System;
using System.Collections.Generic;

namespace DocuSign.CodeExamples.Data
{
    public partial class EmployeeAssign
    {
        public int EmployeeAssignId { get; set; }
        public int? ContactId { get; set; }
        public int UserId { get; set; }
        public int ExchangeId { get; set; }
        public int EmployeeId { get; set; }
        public int SynergyId { get; set; }
        public string IsSynergy { get; set; }
        public short EscrowDocumentsAreAttached { get; set; }
        public short EscrowDocumentsRequestedNotYetReceived { get; set; }
        public short PleaseRequestEscrowDocuments { get; set; }
        public string Note { get; set; }
        public string Task { get; set; }
        public int TaskId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public byte IsActive { get; set; }
    }
}
