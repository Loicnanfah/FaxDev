﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FaxDev.Data;
using FaxDev.Models;

namespace FaxDev.Controllers
{
    public class HomepagesController : Controller
    {
        private readonly FaxDevContext _context;

        public HomepagesController(FaxDevContext context)
        {
            _context = context;
        }

        // GET: Homepages
        public async Task<IActionResult> Index()
        {
              return _context.Homepage != null ? 
                          View(await _context.Homepage.ToListAsync()) :
                          Problem("Entity set 'FaxDevContext.Homepage'  is null.");
        }

        // GET: Homepages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Homepage == null)
            {
                return NotFound();
            }

            var homepage = await _context.Homepage
                .FirstOrDefaultAsync(m => m.Id == id);
            if (homepage == null)
            {
                return NotFound();
            }

            return View(homepage);
        }

        // GET: Homepages/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Homepages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,nom")] Homepage homepage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(homepage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(homepage);
        }

        // GET: Homepages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Homepage == null)
            {
                return NotFound();
            }

            var homepage = await _context.Homepage.FindAsync(id);
            if (homepage == null)
            {
                return NotFound();
            }
            return View(homepage);
        }

        // POST: Homepages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,nom")] Homepage homepage)
        {
            if (id != homepage.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(homepage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HomepageExists(homepage.Id))
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
            return View(homepage);
        }

        // GET: Homepages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Homepage == null)
            {
                return NotFound();
            }

            var homepage = await _context.Homepage
                .FirstOrDefaultAsync(m => m.Id == id);
            if (homepage == null)
            {
                return NotFound();
            }

            return View(homepage);
        }

        // POST: Homepages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Homepage == null)
            {
                return Problem("Entity set 'FaxDevContext.Homepage'  is null.");
            }
            var homepage = await _context.Homepage.FindAsync(id);
            if (homepage != null)
            {
                _context.Homepage.Remove(homepage);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HomepageExists(int id)
        {
          return (_context.Homepage?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
