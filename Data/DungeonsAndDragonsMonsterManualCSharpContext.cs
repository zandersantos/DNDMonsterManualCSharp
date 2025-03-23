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
    }
}
