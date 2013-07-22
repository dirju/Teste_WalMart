using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Site.Models
{
    public class Estado
    {
        [Required(ErrorMessage = "Código é de preenchimento obrigatório!")]
        public int Codigo { get; set; }

        [Required(ErrorMessage = "Pais é de preenchimento obrigatório!")]
        [StringLength(150, ErrorMessage = "Pais não pode ter mais que 150 caracteres.")]
        public string Pais { get; set; }

        [Required(ErrorMessage = "Nome é de preenchimento obrigatório!")]
        [StringLength(150, ErrorMessage = "Nome não pode ter mais que 150 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Sigla é de preenchimento obrigatório!")]
        [StringLength(2, ErrorMessage = "Sigla não pode ter mais que 2 caracteres.")]
        public string Sigla { get; set; }

        [Required(ErrorMessage = "Regiao é de preenchimento obrigatório!")]
        [StringLength(45, ErrorMessage = "Região não pode ter mais que 45 caracteres.")]
        public string Regiao { get; set; }

        public int QtdCidade { get; set; }

    }
}