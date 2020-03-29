using Domain.Empresas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestrutura.Configuration
{
    public sealed class EmpresaConfiguration : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            builder.ToTable("Empresa");
            builder.HasKey(r => r.Id);
            builder.Property(r => r.CNPJ).IsRequired();
            builder.Property(r => r.NomeFantasia).IsRequired();
            builder.Property(r => r.UF).IsRequired();
            builder.HasMany(r => r.Fornecedores).WithOne(r => r.Empresa).IsRequired(false);

        }
    }
}