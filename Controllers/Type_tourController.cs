using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TourCatalog.Data;
using TourCatalog.Models;

namespace TourCatalog.Controllers
{
    public class Type_tourController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Type_tourController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Type_tour
        public async Task<IActionResult> Index()
        {
            return View(await _context.Type_tour.ToListAsync());
        }

        // GET: Type_tour/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var type_tour = await _context.Type_tour
                .FirstOrDefaultAsync(m => m.ID == id);
            if (type_tour == null)
            {
                return NotFound();
            }

            return View(type_tour);
        }

        // GET: Type_tour/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Type_tour/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name")] Type_tour type_tour)
        {
            if (ModelState.IsValid)
            {
                _context.Add(type_tour);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(type_tour);
        }

        // GET: Type_tour/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var type_tour = await _context.Type_tour.FindAsync(id);
            if (type_tour == null)
            {
                return NotFound();
            }
            return View(type_tour);
        }

        // POST: Type_tour/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name")] Type_tour type_tour)
        {
            if (id != type_tour.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(type_tour);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Type_tourExists(type_tour.ID))
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
            return View(type_tour);
        }

        // GET: Type_tour/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var type_tour = await _context.Type_tour
                .FirstOrDefaultAsync(m => m.ID == id);
            if (type_tour == null)
            {
                return NotFound();
            }

            return View(type_tour);
        }

        // POST: Type_tour/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var type_tour = await _context.Type_tour.FindAsync(id);
            if (type_tour != null)
            {
                _context.Type_tour.Remove(type_tour);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Type_tourExists(int id)
        {
            return _context.Type_tour.Any(e => e.ID == id);
        }
    }
}
