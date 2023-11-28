using System;
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
    public class PostVedettesController : Controller
    {
        private readonly FaxDevContext _context;

        public PostVedettesController(FaxDevContext context)
        {
            _context = context;
        }

        // GET: PostVedettes
        public async Task<IActionResult> Index()
        {
              return _context.PostVedette != null ? 
                          View(await _context.PostVedette.ToListAsync()) :
                          Problem("Entity set 'FaxDevContext.PostVedette'  is null.");
        }

        // GET: PostVedettes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PostVedette == null)
            {
                return NotFound();
            }

            var postVedette = await _context.PostVedette
                .FirstOrDefaultAsync(m => m.Id == id);
            if (postVedette == null)
            {
                return NotFound();
            }

            return View(postVedette);
        }

        // GET: PostVedettes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PostVedettes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Cours,ProfName,DatePublication,Photos,PhotosUrl")] PostVedette postVedette)
        {
            if (ModelState.IsValid)
            {
                _context.Add(postVedette);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(postVedette);
        }

        // GET: PostVedettes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PostVedette == null)
            {
                return NotFound();
            }

            var postVedette = await _context.PostVedette.FindAsync(id);
            if (postVedette == null)
            {
                return NotFound();
            }
            return View(postVedette);
        }

        // POST: PostVedettes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Cours,ProfName,DatePublication,Photos,PhotosUrl")] PostVedette postVedette)
        {
            if (id != postVedette.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(postVedette);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostVedetteExists(postVedette.Id))
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
            return View(postVedette);
        }

        // GET: PostVedettes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PostVedette == null)
            {
                return NotFound();
            }

            var postVedette = await _context.PostVedette
                .FirstOrDefaultAsync(m => m.Id == id);
            if (postVedette == null)
            {
                return NotFound();
            }

            return View(postVedette);
        }

        // POST: PostVedettes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PostVedette == null)
            {
                return Problem("Entity set 'FaxDevContext.PostVedette'  is null.");
            }
            var postVedette = await _context.PostVedette.FindAsync(id);
            if (postVedette != null)
            {
                _context.PostVedette.Remove(postVedette);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostVedetteExists(int id)
        {
          return (_context.PostVedette?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
