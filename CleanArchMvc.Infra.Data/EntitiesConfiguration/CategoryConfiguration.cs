using CleanArchMvc.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchMvc.Infra.Data.EntitiesConfiguration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        //Realizando a configuração das propriedades da tabela utilizando o Fluent API
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            //EntityTypeBuilder é uma instancia do entity configuration para gerar de acordo com a classe referenciada

            builder.HasKey(t => t.Id);
            builder.Property(p => p.Name).HasMaxLength(100).IsRequired();

            builder.HasData(
                new Category(1, "Material Escolar"),
                new Category(2, "Eletrônicos"),
                new Category(3, "Acessórios")
             );
        }
    }
}
