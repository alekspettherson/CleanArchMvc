using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Application.Products.Commands;
using CleanArchMvc.Application.Products.Queries;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using MediatR;

namespace CleanArchMvc.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public ProductService( IMapper mapper, IMediator mediator)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            var productsQuery = new GetProductsQuery();

            if (productsQuery == null)
                throw new Exception($"Entity could not be loaded.");
            
            var result = await _mediator.Send(productsQuery);

            return _mapper.Map<IEnumerable<ProductDTO>>(result);
        }

        public async Task<ProductDTO> GetById(int? id)
        {
            if (!id.HasValue)
                throw new Exception($"Id can't be empty!");

            var productQuery = new GetProductByIdQuery(id.Value);

            if (productQuery == null)
                throw new Exception($"Entity could not be loaded.");

            var result = await _mediator.Send(productQuery);

            return _mapper.Map<ProductDTO>(result);
        }

        public async Task<ProductDTO> GetProductCategoryAsync(int? categoryId)
        {
            if (!categoryId.HasValue)
                throw new Exception($"Category Id can't be empty!");

            var productQuery = new GetProductByIdQuery(categoryId.Value);

            if (productQuery == null)
                throw new Exception($"Entity could not be loaded.");

            var result = await _mediator.Send(productQuery);

            return _mapper.Map<ProductDTO>(result);
        }

        public async Task Create(ProductDTO productDTO)
        {
            var productCreateCommand = _mapper.Map<ProductCreateCommand>(productDTO);

            await _mediator.Send(productCreateCommand);
        }

        public async Task Update(ProductDTO productDTO)
        {
            var productUpdateCommand = _mapper.Map<ProductUpdateCommand>(productDTO);

            await _mediator.Send(productUpdateCommand);
        }

        public async Task Remove(int? id)
        {
            if(!id.HasValue)
                throw new Exception($"Id can't be empty!");

            var productRemoveCommand = new ProductRemoveCommand(id.Value);

            if (productRemoveCommand == null)
                throw new Exception($"Entity could not be loaded.");

            await _mediator.Send(productRemoveCommand);

        }
    }
}
