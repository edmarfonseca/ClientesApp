using ClientesApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClientesApp.Infra.Data.Mappings
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("CLIENTE");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("ID");

            builder.Property(c => c.Nome)
                .HasColumnName("NOME")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(c => c.Email)
               .HasColumnName("EMAIL")
               .HasMaxLength(50)
               .IsRequired();

            builder.Property(c => c.Cpf)
               .HasColumnName("CPF")
               .HasMaxLength(11)
               .IsRequired();

            builder.Property(c => c.DataInclusao)
               .HasColumnName("DATAINCLUSAO")
               .IsRequired();

            builder.Property(c => c.DataUltimaAlteracao)
               .HasColumnName("DATAULTIMAALTERACAO")
               .IsRequired();

            builder.Property(c => c.Ativo)
               .HasColumnName("ATIVO")
               .IsRequired();

            builder.HasIndex(c => c.Email)
                .IsUnique();

            builder.HasIndex(c => c.Cpf)
                .IsUnique();
        }
    }
}