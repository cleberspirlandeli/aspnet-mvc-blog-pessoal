using BlogPessoal.Web.Data.Map;
using BlogPessoal.Web.Models;
using System.Data.Entity;

namespace BlogPessoal.Web.Data.Context
{
    public class Context : DbContext
    {
        public Context() : base(typeof(Context).Name)
        {

        }

        public DbSet<Artigo> Artigo { get; set; }
        public DbSet<Autor> Autor { get; set; }
        public DbSet<CategoriaArtigo> CategoriaArtigo { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ArtigoMap());
            modelBuilder.Configurations.Add(new AutorMap());
            modelBuilder.Configurations.Add(new CategoriaArtigoMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}