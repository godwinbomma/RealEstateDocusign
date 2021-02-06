using System;
using System.Collections.Generic;

namespace DocuSign.CodeExamples.Data
{
    public partial class Document
    {
        public int DocId { get; set; }
        public int PropertyId { get; set; }
        public string DocumentName { get; set; }
        public string DocumentOriginalName { get; set; }
        public string DocumentPath { get; set; }
        public string DocumentType { get; set; }
        public int ExtensionId { get; set; }
        public string DocumentDescription { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public short IsFinalClosingDoc { get; set; }
        public byte? IsActive { get; set; }

        public virtual User CreatedByNavigation { get; set; }
    }
}
