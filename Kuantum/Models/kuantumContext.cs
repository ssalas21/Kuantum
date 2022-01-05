using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Kuantum.Models
{
    public partial class kuantumContext : DbContext
    {
        public kuantumContext()
        {
        }

        public kuantumContext(DbContextOptions<kuantumContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Document> Documents { get; set; }
        public virtual DbSet<DocumentPageIndex> DocumentPageIndices { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySQL("Server=kuantum.mysql.database.azure.com;UserID=administrador;Password=Kuantum@123;Database=kuantum;SslMode=Preferred;SslCa=DigiCertGlobalRootCA.crt.pem;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Document>(entity =>
            {
                entity.ToTable("document");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.AuthorEmail)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("author_email");

                entity.Property(e => e.AuthorFullName)
                    .IsRequired()
                    .HasMaxLength(300)
                    .HasColumnName("author_full_name");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .HasColumnName("description");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.Property(e => e.SerialCode)
                    .IsRequired()
                    .HasMaxLength(16)
                    .HasColumnName("serial_code");
            });

            modelBuilder.Entity<DocumentPageIndex>(entity =>
            {
                entity.ToTable("document_page_index");

                entity.HasIndex(e => e.DocumentId, "FK_DocumentPage");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.DocumentId)
                    .HasColumnType("int(11)")
                    .HasColumnName("document_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.Property(e => e.Page)
                    .HasColumnType("int(11)")
                    .HasColumnName("page");

                entity.HasOne(d => d.Document)
                    .WithMany(p => p.DocumentPageIndices)
                    .HasForeignKey(d => d.DocumentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DocumentPage");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
