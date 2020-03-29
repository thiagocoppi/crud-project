using Domain.Fornecedores;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Infraestrutura.Configuration
{
    public sealed class FornecedorConfiguration : IEntityTypeConfiguration<Fornecedor>
    {
        public void Configure(EntityTypeBuilder<Fornecedor> builder)
        {
            builder.ToTable("Fornecedor");
            builder.HasKey(r => r.Id);
            builder.HasOne(r => r.Empresa).WithMany(r => r.Fornecedores);
            builder.Property(r => r.IdentificadorReceitaFederal).IsRequired();
            builder.Property(r => r.Nome).IsRequired();
            builder.OwnsOne(r => r.DadosPessoais).Property(r => r.Identificador).HasColumnName("RG").HasComment("RG");
            builder.OwnsOne(r => r.DadosPessoais).Property(r => r.DataNascimento).HasColumnName("Dtnascimento");
            builder.OwnsOne(r => r.DadosPessoais).Property(r => r.Idade).HasColumnName("Idade");
            builder.Property(r => r.DataCadastro).IsRequired().HasDefaultValueSql("GETDATE()");
        }
    }
}