using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CleanArchMvc.Application.Categories.Queries;
using CleanArchMvc.Application.Products.Queries;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using MediatR;

namespace CleanArchMvc.Application.Categories.Handlers
{
    public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, IEnumerable<Category>>
    {
        public readonly ICategoryRepository _categoryRepository;
        public GetCategoriesQueryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository ?? throw new
                ArgumentException(nameof(categoryRepository));
        }

        public async Task<IEnumerable<Category>> Handle(GetCategoriesQuery request,
            CancellationToken cancellationToken)
        {
            return await _categoryRepository.GetCategoriesAsync();

        }
    }
}
