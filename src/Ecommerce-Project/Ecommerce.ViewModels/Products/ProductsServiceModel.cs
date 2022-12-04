﻿namespace Ecommerce.ViewModels.Products
{
    using System.ComponentModel.DataAnnotations;
    using Ecommerce.ViewModels.Products.Enums;

    public class ProductsServiceModel
    {
        public const int ProductsPerPage = 6;

        public int CurrentPage { get; set; } = 1;

        public int TotalProducts { get; set; }

        public string SearchCategory { get; set; }

        public string SearchNameCriteria { get; set; }

        public decimal CheapestProduct { get; set; }

        public decimal MostExpensiveProduct { get; set; }

        [Display(Name = "Sort By")]
        public ProductsSorting ProductsSorting { get; set; }

        public IEnumerable<ProductViewModel> Products { get; set; }

        public int ImageHeight { get; set; }

        public IEnumerable<ProductCategoryViewModel> Categories { get; set; }
    }
}
