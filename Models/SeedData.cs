using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using DungeonsAndDragonsMonsterManualCSharp.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;

namespace DungeonsAndDragonsMonsterManualCSharp.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new DungeonsAndDragonsMonsterManualCSharpContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<DungeonsAndDragonsMonsterManualCSharpContext>>()))
            {
                //Add in the Admin role and User role
                var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

                // Create Admin role if it doesn't exist
                if (!roleManager.RoleExistsAsync("Admin").Result)
                {
                    roleManager.CreateAsync(new IdentityRole("Admin")).Wait();
                }

                // Create Admin user if it doesn't exist
                var adminEmail = "admin@testing.com";
                var adminUser = userManager.FindByEmailAsync(adminEmail).Result;
                if (adminUser == null)
                {
                    adminUser = new IdentityUser
                    {
                        UserName = adminEmail,
                        Email = adminEmail
                    };

                    userManager.CreateAsync(adminUser, "AdminPassword1");
                    userManager.AddToRoleAsync(adminUser, "Admin");
                }

                if (context.Monster.Any())
                {
                    return; 
                }

                var csvFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "monsters.csv");
                context.Monster.AddRange(
                    new Monster
                    {
                        Name = "Example",
                        ArmourClass = 2,
                        HitPoints = "1D3",
                        HitDice = "1D5",
                        ImageUrl = "Example.URL"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
