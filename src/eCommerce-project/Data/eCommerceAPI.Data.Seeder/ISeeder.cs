﻿namespace eCommerce.Data.Seeder
{
    public interface ISeeder
    {
        Task SeedAsync(EcommerceApiDbContext dbContext, IServiceProvider serviceProvider);
    }
}
