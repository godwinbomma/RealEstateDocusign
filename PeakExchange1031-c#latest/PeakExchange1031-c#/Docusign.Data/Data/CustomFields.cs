using System;
using System.Collections.Generic;

namespace Docusign.Data.Data
{
    public partial class CustomFields
    {
        public int CustomFieldId { get; set; }
        public string CustomFieldName { get; set; }
        public int TypeId { get; set; }
        public int ExchangeId { get; set; }
        public int PropertyTrasactionId { get; set; }
        public int ContactId { get; set; }
        public short AlwaysVisible { get; set; }
        public short Required { get; set; }
        public short ShowColumn { get; set; }
        public short IsExchange { get; set; }
        public short IsReplacement { get; set; }
        public string ToolTip { get; set; }
        public string HelpText { get; set; }
        public byte IsPublic { get; set; }
        public byte IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
