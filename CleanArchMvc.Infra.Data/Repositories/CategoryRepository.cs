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
    public class CategoryRepository : ICategoryRepository
    {
        //declarando a injeção da instancia da classe de contexto
        private ApplicationDbContext _categoryContext;

        //criando o construtor com a injeção
        public CategoryRepository(ApplicationDbContext context)
        {
            _categoryContext = context;
        }

        #region Métodos
        public async Task<Category> CreateAsync(Category category)
        {
            _categoryContext.Add(category);
            await _categoryContext.SaveChangesAsync();
            return category;
        }

        public async Task<Category> GetByIdAsync(int? id)
        {
            return await _categoryContext.Categories.FindAsync(id);
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await _categoryContext.Categories.ToListAsync();
        }

        public async Task<Category> RemoveAsync(Category category)
        {
            _categoryContext.Remove(category);
            await _categoryContext.SaveChangesAsync();
            return category;
        }

        public async Task<Category> UpdateAsync(Category category)
        {
            _categoryContext.Update(category);
            await _categoryContext.SaveChangesAsync();
            return category;
        }
        #endregion

    }
}
