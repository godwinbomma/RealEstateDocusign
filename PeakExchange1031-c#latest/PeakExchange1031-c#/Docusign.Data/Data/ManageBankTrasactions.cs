using System;
using System.Collections.Generic;

namespace Docusign.Data.Data
{
    public partial class ManageBankTrasactions
    {
        public int ManageBankTrasactionsId { get; set; }
        public int ManageBankId { get; set; }
        public DateTime EffectFrom { get; set; }
        public double InterestRate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
