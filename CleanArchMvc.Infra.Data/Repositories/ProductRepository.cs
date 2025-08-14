using System.Collections.Generic;
using System.Threading.Tasks;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchMvc.Infra.Data.Repositories
{
    //Nessa classe é criado os repositórios que irão acessar o nosso context (banco), para realizar as ações
    //Tem a função de criar uma camada abstração entre a camada de acesso a dados e a camada de lógica negócios
    public class ProductRepository : IProductRepository
    {
        //declarando a injeção da instancia da classe de contexto
        private ApplicationDbContext _productContext;

        //criando o construtor com a injeção
        public ProductRepository(ApplicationDbContext context)
        {
            _productContext = context;
        }

        #region Métodos
        public async Task<Product> CreateAsync(Product product)
        {
            _productContext.Add(product);
            await _productContext.SaveChangesAsync();
            return product;
        }

        public async Task<Product> GetByIdAsync(int? id)
        {
            return await _productContext.Products.FindAsync(id);
        }

        public async Task<Product> GetProductCategoryAsync(int? categoryId)
        {
            //eager loading (quando faz o include em uma outra tabela)
            return await _productContext.Products.Include(c => c.Category)
               .SingleOrDefaultAsync(p => p.Id == categoryId);
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _productContext.Products.ToListAsync();
        }

        public async Task<Product> RemoveAsync(Product product)
        {
            _productContext.Remove(product);
            await _productContext.SaveChangesAsync();
            return product;
        }

        public async Task<Product> UpdateAsync(Product product)
        {
            _productContext.Update(product);
            await _productContext.SaveChangesAsync();
            return product;
        }

        #endregion
    }
}
