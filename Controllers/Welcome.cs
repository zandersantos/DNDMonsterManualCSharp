using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using DungeonsAndDragonsMonsterManualCSharp.Models;

namespace DungeonsAndDragonsMonsterManualCSharp.Controllers
{
    public class Welcome : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public string WelcomeEx(string name, int numTimes = 1)
        {
            return HtmlEncoder.Default.Encode($"Hello {name}, NumTimes is: {numTimes}");
        }
       
    }
}
