using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogPessoal.Web.Models
{
    public class Artigo
    {
        public int Id { get; set; }

        [Required]
        public string Titulo { get; set; }

        [Required]
        public string Conteudo { get; set; }

        [Required]
        public DateTime DataPublicacao { get; set; }

        [Required]
        public int IdCategoriaArtigo { get; set; }

        [Required]
        public int IdAutor { get; set; }

        [Required]
        public Byte Removido { get; set; }


    }
}