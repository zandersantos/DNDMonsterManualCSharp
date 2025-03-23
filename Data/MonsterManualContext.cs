using Microsoft.EntityFrameworkCore;
using DungeonsAndDragonsMonsterManualCSharp.Models;

namespace DungeonsAndDragonsMonsterManualCSharp.Data
{
    public class MonsterManualContext : DbContext
    {
        public MonsterManualContext(DbContextOptions<MonsterManualContext> options) : base(options) { } 
    
        public DbSet<Monster> Monsters { get; set; }
        public DbSet<Action> Actions { get; set; }

    }
}
