using System;
using System.Collections.Generic;

namespace Docusign.Data.Data
{
    public partial class ManageBank
    {
        public int BankId { get; set; }
        public string BankName { get; set; }
        public double InterestRate { get; set; }
        public DateTime EffectFrom { get; set; }
        public string Note { get; set; }
        public byte IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
