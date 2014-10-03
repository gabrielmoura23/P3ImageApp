using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using P3ImageApp.Models.Mapping;

namespace P3ImageApp.Models
{
    public partial class BD_P3IMAGEContext : DbContext
    {
        static BD_P3IMAGEContext()
        {
            Database.SetInitializer<BD_P3IMAGEContext>(null);
        }

        public BD_P3IMAGEContext()
            : base("Name=BD_P3IMAGEContext")
        {
        }

        public DbSet<Tab_Campo> Tab_Campo { get; set; }
        public DbSet<Tab_Categoria> Tab_Categoria { get; set; }
        public DbSet<Tab_Subcategoria> Tab_Subcategoria { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new Tab_CampoMap());
            modelBuilder.Configurations.Add(new Tab_CategoriaMap());
            modelBuilder.Configurations.Add(new Tab_SubcategoriaMap());
        }
    }
}
