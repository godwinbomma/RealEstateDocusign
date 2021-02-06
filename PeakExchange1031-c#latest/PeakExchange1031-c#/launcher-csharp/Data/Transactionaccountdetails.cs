using System;
using System.Collections.Generic;

namespace DocuSign.CodeExamples.Data
{
    public partial class Transactionaccountdetails
    {
        public int AccountId { get; set; }
        public int ExchangeId { get; set; }
        public int Count { get; set; }
        public string Description { get; set; }
        public string SenderOrReceiver { get; set; }
        public double? Balance { get; set; }
        public double? IncomingAmount { get; set; }
        public double? OutgoingAmount { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime Date { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public byte IsActive { get; set; }
        public int? UserId { get; set; }

        public virtual User CreatedByNavigation { get; set; }
        public virtual User User { get; set; }
    }
}
