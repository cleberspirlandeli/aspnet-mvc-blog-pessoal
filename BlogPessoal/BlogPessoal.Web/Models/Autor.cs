using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogPessoal.Web.Models
{
    public class Autor
    {
        public int Id { get; set; }
        
        [Required]
        public string Nome { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Senha { get; set; }

        [Required]
        public Byte Administrador { get; set; }

        [Required]
        public DateTime DataCadastro { get; set; }
    }
}