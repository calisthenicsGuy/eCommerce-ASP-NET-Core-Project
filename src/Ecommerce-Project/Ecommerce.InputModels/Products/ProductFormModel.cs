﻿namespace Ecommerce.InputModels.Products
{
    using System.ComponentModel.DataAnnotations;
    using Ecommerce.Data.Models.Enums;
    using static Ecommerce.Data.Common.DataValidation.ProductValidation;

    public class ProductFormModel
    {
        [Required(ErrorMessage = "Name field is required.")]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength, ErrorMessage = "Name field should be between {2} and {1}.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Price field is required.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Status field is required.")]
        public Status Status { get; set; }

        [Required(ErrorMessage = "Quantity field is required.")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Description field is required.")]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength, ErrorMessage = "Description field should be between {2} and {1}.")]
        public string Description { get; set; }

        public IEnumerable<ProductImageInputModel> Images { get; set; }

        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Brand field is required.")]
        public int BrandId { get; set; }

        [Required]
        public string UserId { get; set; }
    }
}
