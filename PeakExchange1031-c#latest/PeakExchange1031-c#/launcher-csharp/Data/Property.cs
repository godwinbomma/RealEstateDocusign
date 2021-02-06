using System;
using System.Collections.Generic;

namespace DocuSign.CodeExamples.Data
{
    public partial class Property
    {
        public int PropertyId { get; set; }
        public int UserId { get; set; }
        public int? ContactId { get; set; }
        public int ExchangeId { get; set; }
        public string PropertyName { get; set; }
        public string PropertyAddress { get; set; }
        public string PropertyType { get; set; }
        public double? ValueOfProperty { get; set; }
        public double? DebitOfProperty { get; set; }
        public string PropertyStatus { get; set; }
        public string OwnershipInterest { get; set; }
        public string OwnershipPerBalance { get; set; }
        public string OwnershipPerClosed { get; set; }
        public string OwnershipPerIdentified { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public byte IsActive { get; set; }

        public virtual User CreatedByNavigation { get; set; }
        public virtual User User { get; set; }
    }
}
