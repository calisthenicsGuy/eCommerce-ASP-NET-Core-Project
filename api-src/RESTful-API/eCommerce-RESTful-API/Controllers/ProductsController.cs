﻿namespace eCommerce_RESTful_API.Controllers
{
    using AutoMapper;
    using eCommerceAPI.Data;
    using eCommerceAPI.Data.Models;
    using eCommerceAPI.InputModels.Products;
    using eCommerceAPI.ViewModels.Products;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    [Route("api/[controller]/")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly EcommerceApiDbContext dbContext;
        private readonly IMapper mapper;

        public ProductsController(ILogger<ProductsController> logger, EcommerceApiDbContext dbContext, IMapper mapper)
        {
            this._logger = logger;
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<ProductViewModel>> GetByIdAsync(int id)
        {
            Product? product = await this.dbContext
                .Products
                .FirstOrDefaultAsync(p => p.Id == id);

            return this.mapper.Map<ProductViewModel>(product);
        }

        [HttpGet("all")]
        public IEnumerable<ProductViewModel> GetAll()
        {
            return this.mapper
                .Map<IEnumerable<ProductViewModel>>(this.dbContext.Products);
        }

        [HttpPost]
        public async Task<JsonResult> CreateAsync([FromBody] ProductFormModel productForm)
        {
            if (!this.ModelState.IsValid)
            {
                IEnumerable<string> errorMessages = this.ModelState
                    .Values
                    .SelectMany(modelState => modelState.Errors)
                    .Select(error => error.ErrorMessage);

                return new JsonResult(errorMessages);
            }

            try
            {
                Product product = new Product()
                {
                    Name = productForm.Name,
                    Price = productForm.Price,
                    Description = productForm.Description,
                    Status = productForm.Status,
                    Quantity = productForm.Quantity,
                    BrandId = productForm.BrandId,
                    UserId = productForm.UserId,
                    CreatedOn = DateTime.UtcNow,
                    IsDeleted = false,
                };

                await this.dbContext.Products.AddAsync(product);
                await this.dbContext.SaveChangesAsync();

                foreach (var category in productForm.Categories)
                {
                    ProductCategory productCategory = new ProductCategory()
                    {
                        ProductId = product.Id,
                        CategoryId = category,
                    };

                    await this.dbContext.ProductCategories.AddAsync(productCategory);
                    await this.dbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message);
            }

            return new JsonResult(this.Ok("Product successfully created!"));
        }
    }
}
