using Microsoft.AspNetCore.Identity;
//using Microsoft.EntityFrameworkCore.Diagnostics;
using Model.SoundWave.Entities;
using Model.SoundWave.Model;

namespace Web.Server.SoundWave
{
    public class Seed
    {
        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope =applicationBuilder.ApplicationServices.CreateScope())
            {
                var rolesManager=serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                if(!await rolesManager.RoleExistsAsync(UserRoles.Admin))
                {
                    await rolesManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                }
                if (!await rolesManager.RoleExistsAsync(UserRoles.User))
                {
                    await rolesManager.CreateAsync(new IdentityRole(UserRoles.User));
                }
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<User>>();
                string adminUserEmail = "butackovilj25@gmail.com";
                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null) {
                    var newAdminUser = new User
                    {
                        UserName = "the_brokenblow",
                        Email = adminUserEmail,
                        EmailConfirmed = true,
                    };
                    await userManager.CreateAsync(newAdminUser, "Conding@1234?");
                    await userManager.CreateAsync(newAdminUser, UserRoles.Admin);
                }

                string appUserEmail = "the_brokenblow@eticet.com";
                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAdminUser = new User
                    {
                        UserName = "PopKek",
                        Email = appUserEmail,
                        EmailConfirmed = true,
                    };
                    await userManager.CreateAsync(newAdminUser, "Conding@1231224?");
                    await userManager.CreateAsync(newAdminUser, UserRoles.User);
                }
            }
        }
    }
}
