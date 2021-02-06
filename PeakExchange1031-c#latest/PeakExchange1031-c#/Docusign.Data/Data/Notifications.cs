using System;
using System.Collections.Generic;

namespace Docusign.Data.Data
{
    public partial class Notifications
    {
        public int NotificationId { get; set; }
        public string MethodName { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public int? ExchangeId { get; set; }
        public short IsDocumentsUpload { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
