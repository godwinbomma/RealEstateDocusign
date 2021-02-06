using System;
using System.Collections.Generic;

namespace DocuSign.CodeExamples.Data
{
    public partial class NotificationsReadId
    {
        public int NotificationsReadId1 { get; set; }
        public int NotificationsId { get; set; }
        public int? UserId { get; set; }
        public short IsRead { get; set; }
        public short IsAdmin { get; set; }
        public DateTime Date { get; set; }
        public int? Count { get; set; }
    }
}
