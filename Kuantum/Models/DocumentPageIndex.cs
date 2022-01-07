using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Kuantum.Models
{
    public partial class DocumentPageIndex
    {
        public int Id { get; set; }
        public int DocumentId { get; set; }
        [StringLength(100)]
        [Required]
        public string Name { get; set; }
        public int Page { get; set; }
        public DateTime Created_at { get; set; }

        public virtual Document Document { get; set; }
    }
}
