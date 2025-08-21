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
    public class CategoryRemoveCommandHandler : IRequestHandler<CategoryRemoveCommand, Category>
    {
        public readonly ICategoryRepository _categoryRepository;
        public CategoryRemoveCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository ?? throw new
                ArgumentException(nameof(categoryRepository));
        }

        public async Task<Category> Handle(CategoryRemoveCommand request,
            CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(request.Id);

            if (category == null)
                throw new ApplicationException($"Entity could not be found.");
            else
            {
                var result = await _categoryRepository.RemoveAsync(category);

                return result;
            }
        }
    }
}
