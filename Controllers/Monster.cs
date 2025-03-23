using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace DungeonsAndDragonsMonsterManualCSharp.Controllers
{
    public class Monster : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public string Welcome(string name, int numTimes = 1)
        {
            return HtmlEncoder.Default.Encode($"Hello {name}, NumTimes is: {numTimes}");
        }
       
    }
}
