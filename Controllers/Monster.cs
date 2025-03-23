using Microsoft.AspNetCore.Mvc;

namespace DungeonsAndDragonsMonsterManualCSharp.Controllers
{
    public class Monster : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
