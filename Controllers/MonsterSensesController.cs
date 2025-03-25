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
    public class MonsterSensesController : Controller
    {
        private readonly DungeonsAndDragonsMonsterManualCSharpContext _context;

        public MonsterSensesController(DungeonsAndDragonsMonsterManualCSharpContext context)
        {
            _context = context;
        }

        // GET: MonsterSenses
        public async Task<IActionResult> Index()
        {
            var dungeonsAndDragonsMonsterManualCSharpContext = _context.MonsterSense.Include(m => m.Monster).Include(m => m.Sense);
            return View(await dungeonsAndDragonsMonsterManualCSharpContext.ToListAsync());
        }

        // GET: MonsterSenses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monsterSense = await _context.MonsterSense
                .Include(m => m.Monster)
                .Include(m => m.Sense)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (monsterSense == null)
            {
                return NotFound();
            }

            return View(monsterSense);
        }

        // GET: MonsterSenses/Create
        public IActionResult Create()
        {
            ViewData["MonsterId"] = new SelectList(_context.Monster, "Id", "Id");
            ViewData["SenseId"] = new SelectList(_context.Sense, "Id", "Id");
            return View();
        }

        // POST: MonsterSenses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SenseRange,MonsterId,SenseId")] MonsterSense monsterSense)
        {
            if (ModelState.IsValid)
            {
                _context.Add(monsterSense);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MonsterId"] = new SelectList(_context.Monster, "Id", "Id", monsterSense.MonsterId);
            ViewData["SenseId"] = new SelectList(_context.Sense, "Id", "Id", monsterSense.SenseId);
            return View(monsterSense);
        }

        // GET: MonsterSenses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monsterSense = await _context.MonsterSense.FindAsync(id);
            if (monsterSense == null)
            {
                return NotFound();
            }
            ViewData["MonsterId"] = new SelectList(_context.Monster, "Id", "Id", monsterSense.MonsterId);
            ViewData["SenseId"] = new SelectList(_context.Sense, "Id", "Id", monsterSense.SenseId);
            return View(monsterSense);
        }

        // POST: MonsterSenses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SenseRange,MonsterId,SenseId")] MonsterSense monsterSense)
        {
            if (id != monsterSense.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(monsterSense);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MonsterSenseExists(monsterSense.Id))
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
            ViewData["MonsterId"] = new SelectList(_context.Monster, "Id", "Id", monsterSense.MonsterId);
            ViewData["SenseId"] = new SelectList(_context.Sense, "Id", "Id", monsterSense.SenseId);
            return View(monsterSense);
        }

        // GET: MonsterSenses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monsterSense = await _context.MonsterSense
                .Include(m => m.Monster)
                .Include(m => m.Sense)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (monsterSense == null)
            {
                return NotFound();
            }

            return View(monsterSense);
        }

        // POST: MonsterSenses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var monsterSense = await _context.MonsterSense.FindAsync(id);
            if (monsterSense != null)
            {
                _context.MonsterSense.Remove(monsterSense);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MonsterSenseExists(int id)
        {
            return _context.MonsterSense.Any(e => e.Id == id);
        }
    }
}
