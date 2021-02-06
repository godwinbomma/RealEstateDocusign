using System;
using System.Collections.Generic;

namespace Docusign.Data.Data
{
    public partial class Country
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public byte IsActive { get; set; }
        public byte IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string CountryNames { get; set; }
    }
}
