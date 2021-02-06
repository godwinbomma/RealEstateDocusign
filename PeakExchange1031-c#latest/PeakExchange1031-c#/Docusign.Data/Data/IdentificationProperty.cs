using System;
using System.Collections.Generic;

namespace Docusign.Data.Data
{
    public partial class IdentificationProperty
    {
        public int IdentificationPropertyId { get; set; }
        public int UserId { get; set; }
        public int? PropertyId { get; set; }
        public int? ContactId { get; set; }
        public int? ExchangeId { get; set; }
        public short Is3PropertyRule { get; set; }
        public short Is200PerRule { get; set; }
        public string PropertyName { get; set; }
        public string PropertyAddress { get; set; }
        public string PropertyType { get; set; }
        public double? ValueOfProperty { get; set; }
        public double? ExchangeCloseDate { get; set; }
        public string PropertyStatus { get; set; }
        public int? IntendtoAquire { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public byte IsActive { get; set; }
    }
}
