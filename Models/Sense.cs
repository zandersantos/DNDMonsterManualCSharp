namespace DungeonsAndDragonsMonsterManualCSharp.Models
{
    public class Sense
    {
        //Properties
        public int Id { get; set; }
        public string SenseType { get; set; }

        //Navigation Properties
        public ICollection<MonsterSense> MonsterSense { get; set; }

    }
}
