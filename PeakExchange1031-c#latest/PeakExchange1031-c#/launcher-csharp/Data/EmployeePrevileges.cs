using System;
using System.Collections.Generic;

namespace DocuSign.CodeExamples.Data
{
    public partial class EmployeePrevileges
    {
        public int EmployeePrevilageId { get; set; }
        public int UserId { get; set; }
        public int PrevilageId { get; set; }
        public short IsView { get; set; }
        public short IsCreate { get; set; }
        public short IsEdit { get; set; }
        public short IsDelete { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public virtual Previleges Previlage { get; set; }
        public virtual User User { get; set; }
    }
}
