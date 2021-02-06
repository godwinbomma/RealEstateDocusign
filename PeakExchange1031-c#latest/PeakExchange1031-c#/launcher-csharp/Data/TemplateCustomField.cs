using System;
using System.Collections.Generic;

namespace DocuSign.CodeExamples.Data
{
    public partial class TemplateCustomField
    {
        public int TcustomFieldId { get; set; }
        public string TcustomFieldName { get; set; }
        public string UniqueCode { get; set; }
        public byte IsContact { get; set; }
        public byte IsExchange { get; set; }
        public byte IsActive { get; set; }
        public int Cfid { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
