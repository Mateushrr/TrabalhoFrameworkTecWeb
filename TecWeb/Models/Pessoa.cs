using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TecWeb.Models
{
    public class Pessoa
    {
        public int id { get; set; }
        
        [Required(ErrorMessage = "O CPF deve ser informado.")]
        [StringLength(14, ErrorMessage = "O CPF deve totalizar 14 dígitos (Incluindo traço e ponto).")]
        [RegularExpression(@"^([0-9]){3}\.([0-9]){3}\.([0-9]){3}-([0-9]){2}$", ErrorMessage = "CPF inválido. Formato válido: 000.000.000-00")]
        [Display(Name = "CPF")]
        public String cpf { get; set; }

        [Required(ErrorMessage = "O nome deve ser informado.")]
        [StringLength(50)]
        [RegularExpression(@"^[a-zA-Z ]*$", ErrorMessage = "Nomes não devem conter números e/ou caracteres.")]
        [Display(Name = "Nome")]
        public String nome { get; set; }

        [Required(ErrorMessage = "A idade deve ser informada.")]
        [StringLength(3, ErrorMessage = "Idade valida de três digitos numéricos.")]
        [RegularExpression(@"^([1-9]|[1-8][0-9]|9[0-9]|1[01][0-9]|120)$", ErrorMessage = "Idade válida entre 1 e 120 anos.")]
        [Display(Name = "Idade")]
        public String idade { get; set; }

        [Required(ErrorMessage = "O email deve ser informado.")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "O email é inválido. Formato: email@domínio.com.")]
        [Display(Name = "Email")]
        public String email { get; set; }
    }
}