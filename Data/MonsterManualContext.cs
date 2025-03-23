using Microsoft.EntityFrameworkCore;
using DungeonsAndDragonsMonsterManualCSharp.Models;

namespace DungeonsAndDragonsMonsterManualCSharp.Data
{
    public class MonsterManualContext : DbContext
    {
        public MonsterManualContext(DbContextOptions<MonsterManualContext> options) : base(options) { } 
    
        public DbSet<Monster> Monsters { get; set; }
        public DbSet<ActionDetail> ActionDetails { get; set; }
        public DbSet<Sense> Senses { get; set; }
        public DbSet<MonsterAction> MonsterActions { get; set; }
        public DbSet<MonsterImage> MonsterImages { get; set; }
        public DbSet<MonsterSense> MonsterSenses { get; set; }


    }
}
