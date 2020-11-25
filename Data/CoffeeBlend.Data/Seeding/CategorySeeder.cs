namespace CoffeeBlend.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using CoffeeBlend.Common;
    using CoffeeBlend.Data.Models;

    public class CategorySeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.CategoryProducts.Any())
            {
                return;
            }

            await dbContext.CategoryProducts.AddAsync(new CategoryProduct { Name = GlobalConstants.CoffeeName });
            await dbContext.CategoryProducts.AddAsync(new CategoryProduct { Name = GlobalConstants.FoodName });
            await dbContext.CategoryProducts.AddAsync(new CategoryProduct { Name = GlobalConstants.DrinksName });
            await dbContext.CategoryProducts.AddAsync(new CategoryProduct { Name = GlobalConstants.DessertsName });

            await dbContext.SaveChangesAsync();
        }
    }
}
