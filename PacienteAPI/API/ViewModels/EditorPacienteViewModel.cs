using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace API.ViewModels
{
    public class EditorPacienteViewModel
    {
        public string Nome { get; set; }

        public string Sobrenome { get; set; }

        [Required(ErrorMessage = "Data de Nascimento é obrigatório")]
        public DateTime DataNascimento { get; set; }

        public string Genero { get; set; }

        [Required(ErrorMessage = "CPF é obrigatório")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "CPF deve conter 11 caracteres, somente números")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "CPF deve conter 11 caracteres, somente números")]
        public string CPF { get; set; }

        [StringLength(9, MinimumLength = 9, ErrorMessage = "RG deve conter 9 caracteres, somente números")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "RG deve conter 9 caracteres, somente números")]
        public string RG { get; set; }

        [StringLength(2, MinimumLength = 2, ErrorMessage = "A UF do RG deve conter 2 caracteres")]
        [RegularExpression("^[A-Za-z]+$", ErrorMessage = "A UF do RG deve conter somente letras")]
        public string UfRG { get; set; }

        [EmailAddress(ErrorMessage = "Endereço de E-Mail inválido")]
        public string Email { get; set; }

        [MaxLength(11, ErrorMessage = "Celular deve conter 11 caracteres, somente números")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Celular deve conter somente números")]
        public string Celular { get; set; }

        [MaxLength(10, ErrorMessage = "Telefone deve conter 10 caracteres, somente números")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Telefone deve conter somente números")]
        public string Telefone { get; set; }

        public string Carteirinha { get; set; }

        [Required(ErrorMessage = "Validade da Carteirinha é obrigatório")]
        public DateTime CarteirinhaValidade { get; set; }

        [Required(ErrorMessage = "Convênio é obrigatório")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "ConvenioId deve conter somente números")]
        public int ConvenioId { get; set; }


        public static bool CanParseDate(string dateString)
        {
            return DateTime.TryParseExact(dateString, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out _);
        }
    }
}