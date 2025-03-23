using Microsoft.AspNetCore.Mvc;

namespace DungeonsAndDragonsMonsterManualCSharp.Controllers
{
    public class Monster : Controller
    {
        public string Index()
        {
            return "Default!";
        }

        public string Welcome()
        {
            return "Welcome Example";
        }
       
    }
}
