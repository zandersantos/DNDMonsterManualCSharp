using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DungeonsAndDragonsMonsterManualCSharp.Models;

namespace DungeonsAndDragonsMonsterManualCSharp.Data
{
    public class DungeonsAndDragonsMonsterManualCSharpContext : DbContext
    {
        public DungeonsAndDragonsMonsterManualCSharpContext (DbContextOptions<DungeonsAndDragonsMonsterManualCSharpContext> options)
            : base(options)
        {
        }

        public DbSet<DungeonsAndDragonsMonsterManualCSharp.Models.Monster> Monster { get; set; } = default!;
        public DbSet<DungeonsAndDragonsMonsterManualCSharp.Models.Action> Action { get; set; } = default!;
        public DbSet<DungeonsAndDragonsMonsterManualCSharp.Models.Sense> Sense { get; set; } = default!;

        /*
         * public DbSet<Monster> Monsters { get; set; }
        public DbSet<ActionDetail> ActionDetails { get; set; }
        public DbSet<Sense> Senses { get; set; }
        public DbSet<MonsterAction> MonsterActions { get; set; }
        public DbSet<MonsterImage> MonsterImages { get; set; }
        public DbSet<MonsterSense> MonsterSenses { get; set; }


         * */

    }
}
