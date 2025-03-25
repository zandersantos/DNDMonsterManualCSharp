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
    public class MonsterImagesController : Controller
    {
        private readonly DungeonsAndDragonsMonsterManualCSharpContext _context;

        public MonsterImagesController(DungeonsAndDragonsMonsterManualCSharpContext context)
        {
            _context = context;
        }

        // GET: MonsterImages
        public async Task<IActionResult> Index()
        {
            var dungeonsAndDragonsMonsterManualCSharpContext = _context.MonsterImage.Include(m => m.Monster);
            return View(await dungeonsAndDragonsMonsterManualCSharpContext.ToListAsync());
        }

        // GET: MonsterImages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monsterImage = await _context.MonsterImage
                .Include(m => m.Monster)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (monsterImage == null)
            {
                return NotFound();
            }

            return View(monsterImage);
        }

        // GET: MonsterImages/Create
        public IActionResult Create()
        {
            ViewData["MonsterId"] = new SelectList(_context.Monster, "Id", "Id");
            return View();
        }

        // POST: MonsterImages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Url,MonsterId")] MonsterImage monsterImage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(monsterImage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MonsterId"] = new SelectList(_context.Monster, "Id", "Id", monsterImage.MonsterId);
            return View(monsterImage);
        }

        // GET: MonsterImages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monsterImage = await _context.MonsterImage.FindAsync(id);
            if (monsterImage == null)
            {
                return NotFound();
            }
            ViewData["MonsterId"] = new SelectList(_context.Monster, "Id", "Id", monsterImage.MonsterId);
            return View(monsterImage);
        }

        // POST: MonsterImages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Url,MonsterId")] MonsterImage monsterImage)
        {
            if (id != monsterImage.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(monsterImage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MonsterImageExists(monsterImage.Id))
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
            ViewData["MonsterId"] = new SelectList(_context.Monster, "Id", "Id", monsterImage.MonsterId);
            return View(monsterImage);
        }

        // GET: MonsterImages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monsterImage = await _context.MonsterImage
                .Include(m => m.Monster)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (monsterImage == null)
            {
                return NotFound();
            }

            return View(monsterImage);
        }

        // POST: MonsterImages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var monsterImage = await _context.MonsterImage.FindAsync(id);
            if (monsterImage != null)
            {
                _context.MonsterImage.Remove(monsterImage);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MonsterImageExists(int id)
        {
            return _context.MonsterImage.Any(e => e.Id == id);
        }
    }
}
