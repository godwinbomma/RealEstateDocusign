using System;
using System.Collections.Generic;

namespace Docusign.Data.Data
{
    public partial class Task
    {
        public int? TaskId { get; set; }
        public string TaskName { get; set; }
        public int? IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public string CreatedOn { get; set; }
    }
}
