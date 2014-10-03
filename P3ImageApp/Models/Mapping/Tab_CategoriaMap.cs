using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace P3ImageApp.Models.Mapping
{
    public class Tab_CategoriaMap : EntityTypeConfiguration<Tab_Categoria>
    {
        public Tab_CategoriaMap()
        {
            // Primary Key
            this.HasKey(t => t.idcategoria);

            // Properties
            this.Property(t => t.descricao)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.slug)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("Tab_Categoria");
            this.Property(t => t.idcategoria).HasColumnName("idcategoria");
            this.Property(t => t.descricao).HasColumnName("descricao");
            this.Property(t => t.slug).HasColumnName("slug");
        }
    }
}
