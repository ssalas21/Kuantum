using System;
using System.Collections.Generic;

#nullable disable

namespace Kuantum.Models
{
    public partial class DocumentPageIndex
    {
        public int Id { get; set; }
        public int DocumentId { get; set; }
        public string Name { get; set; }
        public int Page { get; set; }

        public virtual Document Document { get; set; }
    }
}
