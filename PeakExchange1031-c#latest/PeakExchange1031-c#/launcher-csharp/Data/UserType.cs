using System;
using System.Collections.Generic;

namespace DocuSign.CodeExamples.Data
{
    public partial class UserType
    {
        public UserType()
        {
            ContactsCustomColumn = new HashSet<ContactsCustomColumn>();
        }

        public int UserTypeId { get; set; }
        public string UserTypeName { get; set; }
        public byte IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public virtual ICollection<ContactsCustomColumn> ContactsCustomColumn { get; set; }
    }
}
