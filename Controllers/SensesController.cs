using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DungeonsAndDragonsMonsterManualCSharp.Data;
using DungeonsAndDragonsMonsterManualCSharp.Models;

namespace DungeonsAndDragonsMonsterManualCSharp.Controllers
{
    public class SensesController : Controller
    {
        private readonly DungeonsAndDragonsMonsterManualCSharpContext _context;

        public SensesController(DungeonsAndDragonsMonsterManualCSharpContext context)
        {
            _context = context;
        }

        // GET: Senses
        public async Task<IActionResult> Index()
        {
            return View(await _context.Sense.ToListAsync());
        }

        // GET: Senses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sense = await _context.Sense
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sense == null)
            {
                return NotFound();
            }

            return View(sense);
        }

        // GET: Senses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Senses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SenseType")] Sense sense)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sense);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sense);
        }

        // GET: Senses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sense = await _context.Sense.FindAsync(id);
            if (sense == null)
            {
                return NotFound();
            }
            return View(sense);
        }

        // POST: Senses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SenseType")] Sense sense)
        {
            if (id != sense.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sense);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SenseExists(sense.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(sense);
        }

        // GET: Senses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sense = await _context.Sense
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sense == null)
            {
                return NotFound();
            }

            return View(sense);
        }

        // POST: Senses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sense = await _context.Sense.FindAsync(id);
            if (sense != null)
            {
                _context.Sense.Remove(sense);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SenseExists(int id)
        {
            return _context.Sense.Any(e => e.Id == id);
        }
    }
}
