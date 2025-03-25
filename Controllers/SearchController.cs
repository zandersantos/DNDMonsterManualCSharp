using DungeonsAndDragonsMonsterManualCSharp.Data;
using Microsoft.AspNetCore.Mvc;

namespace DungeonsAndDragonsMonsterManualCSharp.Controllers
{
    public class SearchController : Controller
    {
        private readonly DungeonsAndDragonsMonsterManualCSharpContext _context;

        public SearchController(DungeonsAndDragonsMonsterManualCSharpContext context)
        {
            _context = context;
        }

        public IActionResult Index(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                return View("NoResultsFound"); // A view that says "No results found"
            }

            // Search in Monsters
            var monster = _context.Monster.FirstOrDefault(m => m.Name.Contains(query));
            if (monster != null)
            {
                return RedirectToAction("Details", "Monsters", new { id = monster.Id });
            }

            // Search in Actions
            var action = _context.Action.FirstOrDefault(a => a.Name.Contains(query));
            if (action != null)
            {
                return RedirectToAction("Details", "Actions", new { id = action.Id });
            }

            // Search in Senses
            var sense = _context.Sense.FirstOrDefault(s => s.SenseType.Contains(query));
            if (sense != null)
            {
                return RedirectToAction("Details", "Senses", new { id = sense.Id });
            }

            // If nothing is found
            return View("NoResults");
        }
    }
}
