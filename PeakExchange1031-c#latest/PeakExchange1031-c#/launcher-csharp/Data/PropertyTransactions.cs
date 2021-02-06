using System;
using System.Collections.Generic;

namespace DocuSign.CodeExamples.Data
{
    public partial class PropertyTransactions
    {
        public int PropertyTransactionsId { get; set; }
        public int PropertyId { get; set; }
        public int ExchangeId { get; set; }
        public int Count { get; set; }
        public double Acquiring { get; set; }
        public string PropertyAddress { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public byte IsActive { get; set; }
        public double Amount { get; set; }
    }
}
