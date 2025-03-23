using System.Collections.Generic;

namespace DungeonsAndDragonsMonsterManualCSharp.Models
{
    public class MonsterImage
    {
        //Properties
        public int Id { get; set; }
        public string Url { get; set; }
        public int MonsterId { get; set; }


        //Navigation Properties
        public Monster Monster { get; set; }

    }
}
