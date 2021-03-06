﻿using BlogPessoal.Web.Models;
using System.Data.Entity.ModelConfiguration;

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
                .HasMaxLength(150);

            Property(x => x.Descricao)
                .HasColumnName("descricao")
                .IsOptional()
                .HasMaxLength(300);
        }
    }
}