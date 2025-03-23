using System.Collections.Generic;

namespace DungeonsAndDragonsMonsterManualCSharp.Models
{
    public class Monster
    {
        //Properties
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ArmourClass { get; set; }
        public string  HitPoints { get; set; }
        public string HitDice { get; set; }
        public string ImageUrl { get; set; }

        //Navigation Properties
        /*
        public ICollection<MonsterAction> MonsterAction { get; set; }
        public ICollection<MonsterImage> MonsterImage { get; set; }
        public ICollection<MonsterSense> MonsterSense { get; set; }*/


    }
}
