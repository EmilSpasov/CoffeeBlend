namespace CoffeeBlend.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using CoffeeBlend.Data.Models;

    public class CategorySeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.CategoryProducts.Any())
            {
                return;
            }

            await dbContext.CategoryProducts.AddAsync(new CategoryProduct { Name = "Coffee" });
            await dbContext.CategoryProducts.AddAsync(new CategoryProduct { Name = "Food" });
            await dbContext.CategoryProducts.AddAsync(new CategoryProduct { Name = "Drinks" });
            await dbContext.CategoryProducts.AddAsync(new CategoryProduct { Name = "Desserts" });

            await dbContext.SaveChangesAsync();
        }
    }
}
