using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchMvc.Domain.Entities;
using MediatR;

namespace CleanArchMvc.Application.Categories.Commands
{
    public class CategoryCommand : IRequest<Category>
    {
        public string Name { get; set; }
    }
}
