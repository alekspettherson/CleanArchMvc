using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CleanArchMvc.Application.Products.Queries;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using MediatR;

namespace CleanArchMvc.Application.Products.Handlers
{
    public class GetProductQueriesHandler : IRequestHandler<GetProductsQuery, IEnumerable<Product>>
    {
        public readonly IProductRepository _productRepository;
        public GetProductQueriesHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository ?? throw new
                ArgumentException(nameof(productRepository));
        }

        public async Task<IEnumerable<Product>> Handle(GetProductsQuery request,
            CancellationToken cancellationToken)
        {
            return await _productRepository.GetProductsAsync();

        }
    }
}
