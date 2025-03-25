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
    public class MonsterActionsController : Controller
    {
        private readonly DungeonsAndDragonsMonsterManualCSharpContext _context;

        public MonsterActionsController(DungeonsAndDragonsMonsterManualCSharpContext context)
        {
            _context = context;
        }

        // GET: MonsterActions
        public async Task<IActionResult> Index()
        {
            var dungeonsAndDragonsMonsterManualCSharpContext = _context.MonsterAction.Include(m => m.Action).Include(m => m.Monster);
            return View(await dungeonsAndDragonsMonsterManualCSharpContext.ToListAsync());
        }

        // GET: MonsterActions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monsterAction = await _context.MonsterAction
                .Include(m => m.Action)
                .Include(m => m.Monster)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (monsterAction == null)
            {
                return NotFound();
            }

            return View(monsterAction);
        }

        // GET: MonsterActions/Create
        public IActionResult Create()
        {
            ViewData["ActionId"] = new SelectList(_context.Action, "Id", "Id");
            ViewData["MonsterId"] = new SelectList(_context.Monster, "Id", "Id");
            return View();
        }

        // POST: MonsterActions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description,DamageType,DamageDice,MonsterId,ActionId")] MonsterAction monsterAction)
        {
            if (ModelState.IsValid)
            {
                _context.Add(monsterAction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ActionId"] = new SelectList(_context.Action, "Id", "Id", monsterAction.ActionId);
            ViewData["MonsterId"] = new SelectList(_context.Monster, "Id", "Id", monsterAction.MonsterId);
            return View(monsterAction);
        }

        // GET: MonsterActions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monsterAction = await _context.MonsterAction.FindAsync(id);
            if (monsterAction == null)
            {
                return NotFound();
            }
            ViewData["ActionId"] = new SelectList(_context.Action, "Id", "Id", monsterAction.ActionId);
            ViewData["MonsterId"] = new SelectList(_context.Monster, "Id", "Id", monsterAction.MonsterId);
            return View(monsterAction);
        }

        // POST: MonsterActions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Description,DamageType,DamageDice,MonsterId,ActionId")] MonsterAction monsterAction)
        {
            if (id != monsterAction.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(monsterAction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MonsterActionExists(monsterAction.Id))
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
            ViewData["ActionId"] = new SelectList(_context.Action, "Id", "Id", monsterAction.ActionId);
            ViewData["MonsterId"] = new SelectList(_context.Monster, "Id", "Id", monsterAction.MonsterId);
            return View(monsterAction);
        }

        // GET: MonsterActions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monsterAction = await _context.MonsterAction
                .Include(m => m.Action)
                .Include(m => m.Monster)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (monsterAction == null)
            {
                return NotFound();
            }

            return View(monsterAction);
        }

        // POST: MonsterActions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var monsterAction = await _context.MonsterAction.FindAsync(id);
            if (monsterAction != null)
            {
                _context.MonsterAction.Remove(monsterAction);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MonsterActionExists(int id)
        {
            return _context.MonsterAction.Any(e => e.Id == id);
        }
    }
}
