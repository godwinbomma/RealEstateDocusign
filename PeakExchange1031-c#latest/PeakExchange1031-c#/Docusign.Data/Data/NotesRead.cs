using System;
using System.Collections.Generic;

namespace Docusign.Data.Data
{
    public partial class NotesRead
    {
        public int NotesReadId { get; set; }
        public int NotesId { get; set; }
        public int UserId { get; set; }
        public short IsRead { get; set; }
    }
}
