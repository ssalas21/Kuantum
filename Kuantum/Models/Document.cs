using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Kuantum.Models {
    public partial class Document {
        public Document() {
            DocumentPageIndices = new HashSet<DocumentPageIndex>();
        }

        public int? Id { get; set; }
        [StringLength(100)]
        [Required]
        public string Name { get; set; }
        [StringLength(1000)]
        [Required]
        public string Description { get; set; }
        [StringLength(300)]
        [Required]
        public string AuthorFullName { get; set; }
        [StringLength(100), RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$")]
        [Required]
        public string AuthorEmail { get; set; }
        [StringLength(16), RegularExpression(@"^[0-9A-F]+$")]
        [Required]
        public string SerialCode { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime? Deleted_at { get; set; }
        public DateTime? Updated_at { get; set; }

        public virtual ICollection<DocumentPageIndex> DocumentPageIndices { get; set; }
    }
}
