using System;
using System.Collections.Generic;

namespace DocuSign.CodeExamples.Data
{
    public partial class ContactsCustomColumn
    {
        public int ColumnHeadersId { get; set; }
        public string ActualColumnName { get; set; }
        public string ColumnName { get; set; }
        public int UserId { get; set; }
        public int UserTypeId { get; set; }
        public int FormId { get; set; }
        public short? IsActive { get; set; }
        public short? Isdeleted { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }

        public virtual UserType UserType { get; set; }
    }
}
