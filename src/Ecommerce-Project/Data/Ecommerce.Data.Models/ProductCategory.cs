﻿namespace Ecommerce.Data.Models
{
    using Ecommerce.Data.Common.Models;

    public class ProductCategory : MappingModel
    {
        public int ProductId { get; set; }

        public Product Product { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
