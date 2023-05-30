using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.ViewModels
{
    public class EditorPacienteViewModel
    {
        [Required(ErrorMessage = "O Nome é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O Sobrenome é obrigatório")]
        public string Sobrenome { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Data inválida, formato (MM/DD/AAAA)")]
        [Required(ErrorMessage = "A Data de Nascimento é obrigatório")]
        public DateOnly DataNascimento { get; set; }

        [Required(ErrorMessage = "O Gênero é obrigatório")]
        [MaxLength(1)]
        public string Genero { get; set; }

        [Required(ErrorMessage = "O CPF é obrigatório")]
        [MaxLength(11, ErrorMessage = "CPF deve conter 11 caracteres, somente números")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "CPF deve conter somente números")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "O RG é obrigatório")]
        [MaxLength(9, ErrorMessage = "RG deve conter 9 caracteres, somente números")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "RG deve conter somente números")]
        public string RG { get; set; }

        [Required(ErrorMessage = "A UF do RG é obrigatório")]
        [MaxLength(2, ErrorMessage = "A UF do RG deve conter 2 caracteres")]
        [RegularExpression("^[A-Za-z]+$", ErrorMessage = "A UF do RG deve conter somente letras")]
        public string UfRG { get; set; }

        [EmailAddress(ErrorMessage = "Endereço de E-Mail inválido")]
        public string Email { get; set; }

        [MaxLength(11, ErrorMessage = "Celular deve conter 11 caracteres, somente números")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Celular deve conter somente números")]
        public string Celular { get; set; }

        [MaxLength(10, ErrorMessage = "Telefone deve conter 11 caracteres, somente números")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Telefone deve conter somente números")]
        public string Telefone { get; set; }

        public string Carteirinha { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Data inválida, formato (MM/DD/AAAA)")]
        [Required(ErrorMessage = "A Data da Carteirinha é obrigatória")]
        public DateOnly CarteirinhaValidade { get; set; }

        public int ConvenioId { get; set; }
    }
}