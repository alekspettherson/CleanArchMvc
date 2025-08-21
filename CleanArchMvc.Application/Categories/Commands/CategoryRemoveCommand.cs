using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Categories.Commands
{
    public class CategoryRemoveCommand : CategoryCommand
    {
        public int Id { get; set; }

        public CategoryRemoveCommand(int id)
        {
            Id = id;
        }
    }
}
