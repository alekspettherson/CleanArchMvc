using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CleanArchMvc.Application.Categories.Commands;
using CleanArchMvc.Application.Products.Commands;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using MediatR;

namespace CleanArchMvc.Application.Categories.Handlers
{
    public class CategoryUpdateCommandHandler : IRequestHandler<CategoryUpdateCommand, Category>
    {
        public readonly ICategoryRepository _categoryRepository;
        public CategoryUpdateCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Category> Handle(CategoryUpdateCommand request,
            CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(request.Id);

            if (category == null)
                throw new ApplicationException($"Entity could not be found.");
            else
            {
                category.Update(request.Name);

                return await _categoryRepository.UpdateAsync(category);
            }
        }
    }
}
