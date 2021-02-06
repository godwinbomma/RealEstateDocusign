using System;
using System.Collections.Generic;

namespace Docusign.Data.Data
{
    public partial class Mail
    {
        public int MailId { get; set; }
        public string Mailfrom { get; set; }
        public string MailTo { get; set; }
        public string MailBody { get; set; }
        public string MailSubject { get; set; }
        public string AttachmentFilepath { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public byte? IsActive { get; set; }

        public virtual User CreatedByNavigation { get; set; }
    }
}
