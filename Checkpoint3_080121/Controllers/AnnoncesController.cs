using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Checkpoint3_080121.Data;
using Checkpoint3_080121.Models;
using Microsoft.AspNetCore.Authorization;

namespace Checkpoint3_080121.Controllers
{
    public class AnnoncesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AnnoncesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            List<Annonce> annonces = await _context.Annonce.ToListAsync();
            List<Annonce> lastAnnonces = new List<Annonce>();
            int a = 0;

            foreach (Annonce annonce in annonces)
            {
                a++;
                if (a <= 20)
                {
                    lastAnnonces.Add(annonce);
                }
            }

            return View(lastAnnonces);
        }

        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Body,Price")] Annonce annonce)
        {
            if (ModelState.IsValid)
            {
                _context.Add(annonce);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(annonce);
        }

        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var annonce = await _context.Annonce.FindAsync(id);
            if (annonce == null)
            {
                return NotFound();
            }
            return View(annonce);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Body,Price")] Annonce annonce)
        {
            if (id != annonce.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(annonce);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnnonceExists(annonce.Id))
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
            return View(annonce);
        }

        [Authorize]
        public async Task<IActionResult> Modify(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var annonce = await _context.Annonce
                .FirstOrDefaultAsync(m => m.Id == id);
            if (annonce == null)
            {
                return NotFound();
            }

            return View(annonce);
        }

        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var annonce = await _context.Annonce.FindAsync(id);
            _context.Annonce.Remove(annonce);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnnonceExists(int id)
        {
            return _context.Annonce.Any(e => e.Id == id);
        }
    }
}
