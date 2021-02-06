using System;
using System.Collections.Generic;

namespace DocuSign.CodeExamples.Data
{
    public partial class TaskAssign
    {
        public int TaskAssignId { get; set; }
        public int AssignToId { get; set; }
        public int ExchangeId { get; set; }
        public int TaskId { get; set; }
        public int UserId { get; set; }
        public string Note { get; set; }
        public string Status { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public byte IsActive { get; set; }
    }
}
