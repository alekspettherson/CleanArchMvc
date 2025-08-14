using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchMvc.Domain.Validation;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Category : EntityBase
    {
        public ICollection<Product> Products { get; set; }

        #region Constructors
        public Category(string name)
        {
            ValidateDomain(name);   
        }
        public Category(int id, string name)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id Value!");
            Id = id;
            ValidateDomain(name);
        }

        public void Update(string name)
        {
            ValidateDomain(name);
        }
        #endregion

        #region Private Methods
        private void ValidateDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(name),
                "Invalid Name. Name is Required!");

            DomainExceptionValidation.When(name?.Length < 3,
               "Name is short, minimum 3 characters!");

            Name = name;
        }
        #endregion
    }
}
