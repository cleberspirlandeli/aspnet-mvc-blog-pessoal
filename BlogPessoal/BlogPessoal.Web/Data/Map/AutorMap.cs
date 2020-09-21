using BlogPessoal.Web.Models;
using System.Data.Entity.ModelConfiguration;

namespace BlogPessoal.Web.Data.Map
{
    public class AutorMap : EntityTypeConfiguration<Autor>
    {
        public AutorMap()
        {
            ToTable("autor", "dbo");
            HasKey(x => x.Id);

            Property(x => x.Nome)
                    .HasColumnName("nome")
                    .HasMaxLength(150);

            Property(x => x.Email)
                    .HasColumnName("email")
                    .HasMaxLength(150);

            Property(x => x.Senha)
                       .HasColumnName("senha")
                       .HasMaxLength(50);

            Property(x => x.Administrador)
                       .HasColumnName("administrador");

            Property(x => x.DataCadastro)
                       .HasColumnName("data_cadastro");
        }
        
    }
}