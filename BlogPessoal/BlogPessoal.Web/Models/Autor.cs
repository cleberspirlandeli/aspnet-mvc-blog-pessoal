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
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$",
            ErrorMessage = "O email informado é inválido.")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Required]
        public bool Administrador { get; set; }

        [Required]
        [Display(Name = "Data de Cadastro")]
        [DisplayFormat(ApplyFormatInEditMode =true, DataFormatString ="{0:dd/MM/yyyy}")]
        public DateTime DataCadastro { get; set; }

        public virtual ICollection<Artigo> Artigo { get; set; }
    }
}