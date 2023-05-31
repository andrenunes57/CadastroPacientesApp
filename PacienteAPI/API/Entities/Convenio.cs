namespace API.Entities
{
    public class Convenio
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public IList<Paciente> Pacientes { get; set; }
    }
}