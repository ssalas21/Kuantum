using System;
using System.Collections.Generic;

#nullable disable

namespace Kuantum.Models
{
    public partial class Document
    {
        public Document()
        {
            DocumentPageIndices = new HashSet<DocumentPageIndex>();
        }

        public int? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string AuthorFullName { get; set; }
        public string AuthorEmail { get; set; }
        public string SerialCode { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime? Deleted_at { get; set; }
        public DateTime Updated_at { get; set; }

        public virtual ICollection<DocumentPageIndex> DocumentPageIndices { get; set; }
    }
}
