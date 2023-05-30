namespace API.Entities
{
    public class Convenio
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Paciente Paciente { get; set; }
    }
}