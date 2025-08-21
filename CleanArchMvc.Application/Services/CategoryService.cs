using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchMvc.Application.Categories.Commands;
using CleanArchMvc.Application.Categories.Queries;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Application.Products.Commands;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using MediatR;

namespace CleanArchMvc.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public CategoryService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryDTO>> GetCategories()
        {
            var categoriesQuery = new GetCategoriesQuery();

            if (categoriesQuery == null)
                throw new Exception($"Entity could not be loaded.");

            var result = await _mediator.Send(categoriesQuery);

            return _mapper.Map<IEnumerable<CategoryDTO>>(result);

        }

        public async Task<CategoryDTO> GetById(int? id)
        {
            if (!id.HasValue)
                throw new Exception($"Id can't be empty.");

            var categoryQuery = new GetCategoryByIdQuery(id.Value);

            if (categoryQuery == null)
                throw new Exception($"Entity could not be loaded.");

            var result = await _mediator.Send(categoryQuery);

            return _mapper.Map<CategoryDTO>(result);
        }

        public async Task Add(CategoryDTO categoryDTO)
        {
            var categoryCommand = _mapper.Map<CategoryCreateCommand>(categoryDTO);

            await _mediator.Send(categoryCommand);
        }

        public async Task Update(CategoryDTO categoryDTO)
        {
            var categoryCommand = _mapper.Map<CategoryUpdateCommand>(categoryDTO);

            await _mediator.Send(categoryCommand);
        }

        public async Task Remove(int? id)
        {
            if (!id.HasValue)
                throw new Exception($"Id can't be empty!");

            var categoryRemoveCommand = new CategoryRemoveCommand(id.Value);

            if (categoryRemoveCommand == null)
                throw new Exception($"Entity could not be loaded.");

            await _mediator.Send(categoryRemoveCommand);

        }
    }
}
