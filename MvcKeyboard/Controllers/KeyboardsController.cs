﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcKeyboard.Data;
using MvcKeyboard.Models;

namespace MvcKeyboard.Controllers
{
    public class KeyboardsController : Controller
    {
        private readonly MvcKeyboardContext _context;

        public KeyboardsController(MvcKeyboardContext context)
        {
            _context = context;
        }

        // GET: Movies
        public async Task<IActionResult> Index(string keyboardType, string searchString)
        {
            // Use LINQ to get list of types.
            IQueryable<string> typeQuery = from k in _context.Keyboard
                                            orderby k.Type
                                            select k.Type;

            var keyboards = from k in _context.Keyboard
                         select k;

            if (!string.IsNullOrEmpty(searchString))
            {
                keyboards = keyboards.Where(s => s.Name.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(keyboardType))
            {
                keyboards = keyboards.Where(x => x.Type == keyboardType);
            }

            var keyboardTypeVM = new KeyboardTypeViewModel
            {
                Types = new SelectList(await typeQuery.Distinct().ToListAsync()),
                Keyboards = await keyboards.ToListAsync()
            };

            return View(keyboardTypeVM);
        }

        // GET: Keyboards/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var keyboard = await _context.Keyboard
                .FirstOrDefaultAsync(m => m.Id == id);
            if (keyboard == null)
            {
                return NotFound();
            }

            return View(keyboard);
        }

        // GET: Keyboards/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Keyboards/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("Id,Name,ReleaseDate,Color,Switch,Type,Price,Rating")] Keyboard keyboard)
        {
            if (ModelState.IsValid)
            {
                _context.Add(keyboard);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(keyboard);
        }

        // GET: Keyboards/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var keyboard = await _context.Keyboard.FindAsync(id);
            if (keyboard == null)
            {
                return NotFound();
            }
            return View(keyboard);
        }

        // POST: Keyboards/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,ReleaseDate,Color,Switch,Type,Price,Rating")] Keyboard keyboard)
        {
            if (id != keyboard.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(keyboard);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KeyboardExists(keyboard.Id))
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
            return View(keyboard);
        }

        // GET: Keyboards/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var keyboard = await _context.Keyboard
                .FirstOrDefaultAsync(m => m.Id == id);
            if (keyboard == null)
            {
                return NotFound();
            }

            return View(keyboard);
        }

        // POST: Keyboards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var keyboard = await _context.Keyboard.FindAsync(id);
            _context.Keyboard.Remove(keyboard);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KeyboardExists(int id)
        {
            return _context.Keyboard.Any(e => e.Id == id);
        }
    }
}
