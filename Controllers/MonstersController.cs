﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DungeonsAndDragonsMonsterManualCSharp.Data;
using DungeonsAndDragonsMonsterManualCSharp.Models;
using Microsoft.AspNetCore.Authorization;
using System.Threading;

namespace DungeonsAndDragonsMonsterManualCSharp.Controllers
{
    public class MonstersController : Controller
    {
        private readonly DungeonsAndDragonsMonsterManualCSharpContext _context;

        public MonstersController(DungeonsAndDragonsMonsterManualCSharpContext context)
        {
            _context = context;
        }

        // GET: Monsters
        public async Task<IActionResult> Index()
        {
            return View(await _context.Monster.ToListAsync());
        }

        // GET: Monsters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var monster = await _context.Monster.FirstOrDefaultAsync(m => m.Id == id);
            if (monster == null)
            {
                return NotFound();
            }
            // Retrieve actions associated with the monster
            var monsterActions = await _context.MonsterAction
                .Where(ma => ma.MonsterId == id)
                .Select(ma => ma.Action)
                .ToListAsync();

            // Pass actions to the view
            ViewData["MonsterActions"] = monsterActions;

            // Retrieve senses associated with the monster
            var monsterSenses = await _context.MonsterSense
                .Where(ms => ms.MonsterId == id)
                .Select(ms => ms.Sense)
                .ToListAsync();

            // Pass senses to the view using ViewData
            ViewData["MonsterSenses"] = monsterSenses;

            return View(monster);
        }

        // GET: Monsters/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Monsters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,ArmourClass,HitPoints,HitDice,ImageUrl")] Monster monster)
        {

            if (ModelState.IsValid)
            {
                _context.Add(monster);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(monster);
        }

        // GET: Monsters/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monster = await _context.Monster.FindAsync(id);
            if (monster == null)
            {
                return NotFound();
            }
            return View(monster);
        }

        // POST: Monsters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,ArmourClass,HitPoints,HitDice,ImageUrl")] Monster monster)
        {
            if (id != monster.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(monster);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MonsterExists(monster.Id))
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
            return View(monster);
        }

        // GET: Monsters/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monster = await _context.Monster
                .FirstOrDefaultAsync(m => m.Id == id);
            if (monster == null)
            {
                return NotFound();
            }

            return View(monster);
        }

        // POST: Monsters/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var monster = await _context.Monster.FindAsync(id);
            if (monster != null)
            {
                _context.Monster.Remove(monster);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MonsterExists(int id)
        {
            return _context.Monster.Any(e => e.Id == id);
        }
    }
}
