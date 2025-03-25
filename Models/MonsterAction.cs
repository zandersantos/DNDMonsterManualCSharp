using System.Collections.Generic;

namespace DungeonsAndDragonsMonsterManualCSharp.Models
{
    public class MonsterAction
    {
        //Properties
        public int Id { get; set; }
        public string Description { get; set; }
        public string? DamageType { get; set; }
        public string DamageDice { get; set; }
        public int MonsterId { get; set; }
        public int ActionId { get; set; }

        //Navigation Properties
        public Monster Monster { get; set; }
        public Action Action { get; set; }

    }
}
