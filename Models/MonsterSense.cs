namespace DungeonsAndDragonsMonsterManualCSharp.Models
{
    public class MonsterSense
    {
        //Properties
        public string SenseRange { get; set; }

        //Navigation Properties
        public Monster Monster { get; set; }
        public Sense Sense { get; set; }
    }
}
