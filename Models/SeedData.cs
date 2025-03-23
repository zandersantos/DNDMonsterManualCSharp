using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using DungeonsAndDragonsMonsterManualCSharp.Data;
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
              
                if (context.Monster.Any())
                {
                    return; 
                }
                context.Monster.AddRange(
                    new Monster
                    {
                        Name = "Example",
                        Description = "Example",
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
