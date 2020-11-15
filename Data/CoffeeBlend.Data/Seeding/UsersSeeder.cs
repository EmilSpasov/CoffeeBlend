namespace CoffeeBlend.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using CoffeeBlend.Common;
    using CoffeeBlend.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;

    public class UsersSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var admin = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            if (!dbContext.Users.Any(u => u.Roles.Any(r => r.RoleId == dbContext.Roles.FirstOrDefault(x => x.Name == GlobalConstants.AdministratorRoleName).Id)))
            {
                await AdminSeeder(admin);
            }
        }

        private static async Task AdminSeeder(UserManager<ApplicationUser> admin)
        {
            var user = new ApplicationUser
            {
                Email = GlobalConstants.AdminEmailName,
                UserName = GlobalConstants.AdminUsername,
                FirstName = GlobalConstants.AdminFirstName,
                LastName = GlobalConstants.AdminLastName,
                EmailConfirmed = true,
                PhoneNumber = GlobalConstants.AdminPhoneNumber,
            };

            var result = await admin.CreateAsync(user, GlobalConstants.AdminPassword);

            if (result.Succeeded)
            {
                await admin.AddToRoleAsync(user, GlobalConstants.AdministratorRoleName);
            }
        }
    }
}
