namespace DungeonsAndDragonsMonsterManualCSharp.Models
{
    public class MonsterSense
    {
        //Properties
        public int Id { get; set; }
        public string SenseRange { get; set; }
        public int MonsterId { get; set; }
        public int SenseId { get; set; }
        //Navigation Properties
        public Monster Monster { get; set; }
        public Sense Sense { get; set; }
    }
}
