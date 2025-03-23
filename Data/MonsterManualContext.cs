using Microsoft.EntityFrameworkCore;

namespace DungeonsAndDragonsMonsterManualCSharp.Data
{
    public class MonsterManualContext : DbContext
    {
        public MonsterManualContext(DbContextOptions<MonsterManualContext> options) : base(options) { } 
    
    
    }
}
