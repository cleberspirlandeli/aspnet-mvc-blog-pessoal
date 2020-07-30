using BlogPessoal.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace BlogPessoal.Web.Data.Map
{
    public class CategoriaArtigoMap : EntityTypeConfiguration<CategoriaArtigo>
    {
        public CategoriaArtigoMap()
        {
            ToTable("categoria_artigo", "dbo");
            HasKey(x => x.Id);

            Property(x => x.Nome)
                .HasColumnName("nome")
                .IsOptional()
                .HasMaxLength(150);

            Property(x => x.Descricao)
                .HasColumnName("descricao")
                .IsOptional()
                .HasMaxLength(300);
        }
    }
}