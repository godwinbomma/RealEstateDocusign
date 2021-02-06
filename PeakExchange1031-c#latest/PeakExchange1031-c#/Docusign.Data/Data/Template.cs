using System;
using System.Collections.Generic;

namespace Docusign.Data.Data
{
    public partial class Template
    {
        public int TemplateId { get; set; }
        public string TemplateName { get; set; }
        public string Description { get; set; }
        public string Sharing { get; set; }
        public string TemplatePath { get; set; }
        public string TemplateFileName { get; set; }
        public byte IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public virtual User CreatedByNavigation { get; set; }
    }
}
