using API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Data.Mappings
{
    public class PacienteMap : IEntityTypeConfiguration<Paciente>
    {
        public void Configure(EntityTypeBuilder<Paciente> builder)
        {
            // Tabela
            builder
                .ToTable("Paciente");

            // Chave Primária
            builder
                .HasKey(x => x.Id);

            // Identity
            builder
                .Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            // Propriedades
            builder
                .Property(x => x.CPF)
                .IsRequired();

            builder
                .Property(x => x.DataNascimento)
                .HasColumnType("DATE");

            builder
                .Property(x => x.CarteirinhaValidade)
                .HasColumnType("DATE");

            // Índices
            builder
                .HasIndex(x => x.CPF, "IX_Paciente_CPF")
                .IsUnique();

            // Relacionamentos
            builder
                .HasOne(x => x.Convenio)
                .WithMany(x => x.Pacientes)
                .HasForeignKey(x => x.ConvenioId)
                .HasConstraintName("FK_Paciente_Convenio")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}