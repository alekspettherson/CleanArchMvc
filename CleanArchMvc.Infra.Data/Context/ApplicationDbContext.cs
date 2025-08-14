using CleanArchMvc.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchMvc.Infra.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        /* DbContext permiti realizar as seguintes tarefas:
          - Gerenciar conexão com banco
          - Configurar modelo e relacionamento
          - Consultar banco de dados
          - Salvar dados no banco
          - Configurar o controle de alterações
          - Cache
          - Gerenciar transações
         */

        //Definindo as opções do contexto, passando o contexto
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        //Definando os nomes das tabelas utilizando o dbSet (mapeamento de ORM)
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }


        //Esse método permiti a realização da configuração do modelo utilizando a fluent api
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            //ApplyConfigurationsFromAssembly -> esse método é responsável por aplicar as configurações que foram feitas nas classes de Configuration
        }

    }
}
  