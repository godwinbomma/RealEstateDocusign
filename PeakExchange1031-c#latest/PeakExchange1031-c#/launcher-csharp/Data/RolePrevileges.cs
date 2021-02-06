using System;
using System.Collections.Generic;

namespace DocuSign.CodeExamples.Data
{
    public partial class RolePrevileges
    {
        public int RolePrevilegesId { get; set; }
        public int UserTypeId { get; set; }
        public int PrevilageId { get; set; }
        public short IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
