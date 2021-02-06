using System;
using System.Collections.Generic;

namespace Docusign.Data.Data
{
    public partial class Notes
    {
        public int NoteId { get; set; }
        public int? ContactId { get; set; }
        public int? ExchangeId { get; set; }
        public string Subject { get; set; }
        public byte? Private { get; set; }
        public string Note { get; set; }
        public DateTime? DateTime { get; set; }
        public string Tags { get; set; }
        public string Attachments { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public byte? IsActive { get; set; }
        public int? CreatedByNavigationUserId { get; set; }

        public virtual User CreatedByNavigationUser { get; set; }
    }
}
