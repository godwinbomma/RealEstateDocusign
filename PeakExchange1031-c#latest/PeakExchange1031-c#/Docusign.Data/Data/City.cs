using System;
using System.Collections.Generic;

namespace Docusign.Data.Data
{
    public partial class City
    {
        public int CityId { get; set; }
        public int StateId { get; set; }
        public string CityName { get; set; }
        public string Notes { get; set; }
        public byte IsActive { get; set; }
        public byte IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string CityNotes { get; set; }
    }
}
