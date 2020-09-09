using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VemDoBem.Domain.Entidades;

namespace VemDoBem.Infra.Data.Mapeamentos
{
    public class UsuarioMapeamento : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.Property(d => d.Email).IsUnicode(false).HasMaxLength(80);
            builder.Property(d => d.Nome).IsUnicode(false).HasMaxLength(80);
            builder.OwnsOne(d => d.Endereco, d => 
            {
                d.Property(e => e.Cep).IsRequired().IsUnicode(false).HasMaxLength(8);
                d.Property(e => e.Rua).IsRequired().IsUnicode(false).HasMaxLength(120);
                d.Property(e => e.Uf).IsRequired().IsUnicode(false).HasMaxLength(2);
                d.Property(e => e.Municipio).IsRequired().IsUnicode(false).HasMaxLength(80);
            });
        }
    }
}
