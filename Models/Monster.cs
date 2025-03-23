using Microsoft.EntityFrameworkCore.Migrations;

namespace DungeonsAndDragonsMonsterManualCSharp.Models
{
    public class Monster
    {
        //Properties
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int HitPoints { get; set; }
        public string HitDice { get; set; }
        public string ImageUrl { get; set; }


    }
}
