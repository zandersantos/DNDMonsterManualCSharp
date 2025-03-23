namespace DungeonsAndDragonsMonsterManualCSharp.Models
{
    public class MonsterImage
    {
        //Properties
        public string Url { get; set; }
       
        //Navigation Properties
        public Monster Monster { get; set; }

    }
}
