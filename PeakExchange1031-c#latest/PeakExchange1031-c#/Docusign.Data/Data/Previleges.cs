using System;
using System.Collections.Generic;

namespace Docusign.Data.Data
{
    public partial class Previleges
    {
        public Previleges()
        {
            EmployeePrevileges = new HashSet<EmployeePrevileges>();
        }

        public int PrevilageId { get; set; }
        public string ModuleName { get; set; }
        public string PrivilegeName { get; set; }
        public byte IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public virtual ICollection<EmployeePrevileges> EmployeePrevileges { get; set; }
    }
}
