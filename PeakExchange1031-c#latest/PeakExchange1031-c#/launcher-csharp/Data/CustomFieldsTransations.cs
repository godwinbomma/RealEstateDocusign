using System;
using System.Collections.Generic;

namespace DocuSign.CodeExamples.Data
{
    public partial class CustomFieldsTransations
    {
        public int CftransationsId { get; set; }
        public int CustomFieldId { get; set; }
        public int PropertyTrasactionId { get; set; }
        public int ExchangeId { get; set; }
        public int ContactId { get; set; }
        public string Value { get; set; }
        public byte IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
