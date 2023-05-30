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
                .IsRequired()
                .HasAnnotation("Check_Paciente_CPF_Pattern",
                    "CPF LIKE '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'");

            builder
                .Property(x => x.Telefone)
                .HasAnnotation("Check_Paciente_Telefone_Pattern",
                    "Telefone LIKE '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'");

            builder
                .Property(x => x.Celular)
                .HasAnnotation("Check_Paciente_Celular_Pattern",
                    "Celular LIKE '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'");

            builder
                .Property(x => x.DataNascimento)
                .HasConversion<DateOnlyConverter>()
                .HasColumnType("DATE");

            builder
                .Property(x => x.CarteirinhaValidade)
                .HasConversion<DateOnlyConverter>()
                .HasColumnType("DATE");

            builder
                .HasAnnotation("Check_Paciente_TelephoneOrCellPhones",
                    "([Telephone] IS NOT NULL OR [CellPhones] IS NOT NULL) AND ([Telephone] <> '' OR [CellPhones] <> '')");

            // Índices
            builder
                .HasIndex(x => x.CPF, "IX_Paciente_CPF")
                .IsUnique();

            // Relacionamentos
            builder
                .HasOne(x => x.Convenio)
                .WithOne(x => x.Paciente)
                .HasForeignKey<Paciente>(p => p.ConvenioId)
                .HasConstraintName("FK_Paciente_Convenio")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}