namespace API.Entities
{
    public class Paciente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateOnly DataNascimento { get; set; }
        public string Genero { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public string UfRG { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }
        public string Telefone { get; set; }
        public Convenio Convenio { get; set; }
        public string Carteirinha { get; set; }
        public DateOnly CarteirinhaValidade { get; set; }
        public int ConvenioId { get; set; }
    }
}