using System;
using System.Collections.Generic;

namespace DocuSign.CodeExamples.Data
{
    public partial class CustomColumn
    {
        public int ColumnHeadersId { get; set; }
        public string ColumnHeadersName { get; set; }
        public int UserTypeId { get; set; }
        public short IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
