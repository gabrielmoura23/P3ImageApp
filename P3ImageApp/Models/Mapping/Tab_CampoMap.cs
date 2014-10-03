using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace P3ImageApp.Models.Mapping
{
    public class Tab_CampoMap : EntityTypeConfiguration<Tab_Campo>
    {
        public Tab_CampoMap()
        {
            // Primary Key
            this.HasKey(t => t.idcampo);

            // Properties
            this.Property(t => t.descricao)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.tipo)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.lista)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("Tab_Campo");
            this.Property(t => t.idcampo).HasColumnName("idcampo");
            this.Property(t => t.idsubcategoria).HasColumnName("idsubcategoria");
            this.Property(t => t.ordem).HasColumnName("ordem");
            this.Property(t => t.descricao).HasColumnName("descricao");
            this.Property(t => t.tipo).HasColumnName("tipo");
            this.Property(t => t.lista).HasColumnName("lista");

            // Relationships
            this.HasRequired(t => t.Tab_Subcategoria)
                .WithMany(t => t.Tab_Campo)
                .HasForeignKey(d => d.idsubcategoria);

        }
    }
}
