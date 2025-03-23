using System.Collections.Generic;

namespace DungeonsAndDragonsMonsterManualCSharp.Models
{
    public class Action
    {
        //Properties
        public int Id { get; set; }
        public string Name { get; set; }

        //Navigation Properties
        public ICollection<MonsterAction> MonsterAction { get; set; }
    }
}
