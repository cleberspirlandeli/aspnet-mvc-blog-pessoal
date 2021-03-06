﻿using BlogPessoal.Web.Models;
using System.Data.Entity.ModelConfiguration;

namespace BlogPessoal.Web.Data.Map
{
    public class ArtigoMap : EntityTypeConfiguration<Artigo>
    {
        public ArtigoMap()
        {
            ToTable("artigo", "dbo");
            HasKey(x => x.Id);

            Property(x => x.Titulo)
                    .HasColumnName("titulo")
                    .HasMaxLength(300);

            Property(x => x.Conteudo)
                    .HasColumnName("conteudo")
                    .HasMaxLength(300);

            Property(x => x.DataPublicacao)
                    .HasColumnName("data_publicacao");

            Property(x => x.IdCategoriaArtigo)
                    .HasColumnName("categoria_artigo_id");

            Property(x => x.IdAutor)
                    .HasColumnName("autor_id");

            Property(x => x.Removido)
                    .HasColumnName("removido");

            HasRequired(t => t.CategoriaArtigo)
                .WithMany(t => t.Artigo)
                .HasForeignKey(t => t.IdCategoriaArtigo)
                .WillCascadeOnDelete(false);

            HasRequired(t => t.Autor)
                .WithMany(t => t.Artigo)
                .HasForeignKey(t => t.IdAutor)
                .WillCascadeOnDelete(false);
        }
    }
}