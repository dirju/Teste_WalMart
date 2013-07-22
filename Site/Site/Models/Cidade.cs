using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Site.Models
{
    [Serializable]
    public class Cidade
    {
        [Required(ErrorMessage = "Código é de preenchimento obrigatório!")]
        public int Codigo { get; set; }

        [Required(ErrorMessage = "Estado é de preenchimento obrigatório!")]
        public Estado Estado { get; set; }

        [Required(ErrorMessage = "Nome é de preenchimento obrigatório!")]
        [StringLength(150, ErrorMessage = "Nome não pode ter mais que 150 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Capital é de preenchimento obrigatório!")]
        public bool Capital { get; set; }

        public IEnumerable<Estado> TodosEstados { get; set; }
    }
}