namespace DungeonsAndDragonsMonsterManualCSharp.Models
{
    public class MonsterAction
    {
        //Properties
        public string Description { get; set; }
        public string DamageType { get; set; }
        public string DamageDice { get; set; }

        //Navigation Properties
        public Monster Monster { get; set; }
        public Action Action { get; set; }

    }
}
