using System;
using CleanArchMvc.Domain.Entities;
using FluentAssertions;
using Xunit;


namespace CleanArchMvc.Domain.Tests
{
    public class ProductUnitTests1
    {
        [Fact(DisplayName = "Create Product With Valid State")]
        public void CreateProduct_WithValidParameter_ResultObjectValidState()
        {
            Action action = () => new Product(1, "Product name", "Product Description", 9.99m, 99, "product image");
            action.Should()
                .NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();

        }

        [Fact(DisplayName = "Create Product With Invalid Id")]
        public void CreateProduct_NegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Product(-1, "Product name", "Product Description", 9.99m, 99, "product image");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid ID Value!");
        }

        [Fact(DisplayName = "Create Product With Short Description Value")]
        public void CreateProduct_ShortDescriptionValue_DomainExceptionInvalidId()
        {
            Action action = () => new Product(1, "Product name", "Prod", 9.99m, 99, "product image");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().WithMessage("Name is short, minimum 5 characters!");
        }

        [Fact(DisplayName = "Create Product With Short Name Value")]
        public void CreateProduct_ShortNameValue_DomainExceptionInvalidId()
        {
            Action action = () => new Product(1, "Pr", "Product Description", 9.99m, 99, "product image");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().WithMessage("Name is short, minimum 3 characters!");
        }

        [Fact(DisplayName = "Create Product With Long Image Value")]
        public void CreateProduct_LongImageValue_DomainExceptionInvalidId()
        {
            Action action = () => new Product(1, "Product name", "Product Description", 9.99m, 99, "product image tooo looooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooonnnnnngggggggggggggg product image tooo looooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooonnnnnngggggggggggggg");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().WithMessage("Image is too long, maximum is 250 characters!");
        }

        [Fact(DisplayName = "Create Product With Missing Name")]
        public void CreateProdut_MissingNameValue_DomainExceptionInvalidId()
        {
            Action action = () => new Product(1, "", "Product Description", 9.99m, 99, "product image");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid Name. Name is Required!");
        }

        [Fact(DisplayName = "Create Product With Missing Description")]
        public void CreateProdut_MissingDescriptionValue_DomainExceptionInvalidId()
        {
            Action action = () => new Product(1, "Product name", "", 9.99m, 99, "product image");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid Description. Description is Required!");
        }

        [Fact(DisplayName = "Create Product With Null Name Value")]
        public void CreateProduct_WithNullNameValue_DomainExceptionInvalidId()
        {
            Action action = () => new Product(1, null , "Product Description", 9.99m, 99, "product image");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Product With Null Description Value")]
        public void CreateProduct_WithNullDescriptionValue_DomainExceptionInvalidId()
        {
            Action action = () => new Product(1, "Product name", null, 9.99m, 99, "product image");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Product With Invalid Price Value")]
        public void CreateProduct_WithInvalidPriceValue_DomainExceptionInvalidId()
        {
            Action action = () => new Product(1, "Product name", "Product Description", 0m, 99, "product image");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid price value!");
        }

        [Theory]
        [InlineData(-5)]
        public void CreateProduct_WithInvalidStockValue_DomainExceptionInvalidId(int value)
        {
            Action action = () => new Product(1, "Product name", "Product Description", 9.99m, value, "product image");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid stock value!");
        }

        [Fact(DisplayName = "Create Product With Negative Price Value")]
        public void CreateProduct_WithNegativePriceValue_DomainExceptionInvalidId()
        {
            Action action = () => new Product(1, "Product name", "Product Description", -1.1m, 99, "product image");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid price value!");
        }

        [Fact(DisplayName = "Create Product With Null Image Value")]
        public void CreateProduct_NullImageValue_DomainExceptionInvalidId()
        {
            Action action = () => new Product(1, "Product name", "Product Description", 9.99m, 99, null);
            action.Should()
                .NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Product With Missing Image Value")]
        public void CreateProduct_MissingImageValue_DomainExceptionInvalidId()
        {
            Action action = () => new Product(1, "Product name", "Product Description", 9.99m, 99, "");
            action.Should()
                .NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Product With Null Image With No Null Reference Exception")]
        public void CreateProduct_NullImageValue_NoNullReferenceException()
        {
            Action action = () => new Product(1, "Product name", "Product Description", 9.99m, 99, null);
            action.Should()
                .NotThrow<NullReferenceException>();
        }

        [Fact(DisplayName = "Create Product With Null Name With No Null Reference Exception")]
        public void CreateProduct_NullNameValue_NoNullReferenceException()
        {
            Action action = () => new Product(1, null, "Product Description", 9.99m, 99, "product image");
            action.Should()
                .NotThrow<NullReferenceException>();
        }

        [Fact(DisplayName = "Create Product With Null Description With No Null Reference Exception")]
        public void CreateProduct_NullDescriptionValue_NoNullReferenceException()
        {
            Action action = () => new Product(1, "Product name", null , 9.99m, 99, "product image");
            action.Should()
                .NotThrow<NullReferenceException>();
        }
    }
}
