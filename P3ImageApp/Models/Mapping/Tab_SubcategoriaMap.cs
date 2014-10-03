using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace P3ImageApp.Models.Mapping
{
    public class Tab_SubcategoriaMap : EntityTypeConfiguration<Tab_Subcategoria>
    {
        public Tab_SubcategoriaMap()
        {
            // Primary Key
            this.HasKey(t => t.idsubcategoria);

            // Properties
            this.Property(t => t.descricao)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.slug)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("Tab_Subcategoria");
            this.Property(t => t.idsubcategoria).HasColumnName("idsubcategoria");
            this.Property(t => t.idcategoria).HasColumnName("idcategoria");
            this.Property(t => t.descricao).HasColumnName("descricao");
            this.Property(t => t.slug).HasColumnName("slug");

            // Relationships
            this.HasRequired(t => t.Tab_Categoria)
                .WithMany(t => t.Tab_Subcategoria)
                .HasForeignKey(d => d.idcategoria);

        }
    }
}
