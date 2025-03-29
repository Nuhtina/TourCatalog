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
    public class TripCatalogsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TripCatalogsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TripCatalogs
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.TripCatalog.Include(t => t.Country).Include(t => t.Hotel).Include(t => t.Town).Include(t => t.Transport).Include(t => t.Type_tours);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: TripCatalogs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tripCatalog = await _context.TripCatalog
                .Include(t => t.Country)
                .Include(t => t.Hotel)
                .Include(t => t.Town)
                .Include(t => t.Transport)
                .Include(t => t.Type_tours)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (tripCatalog == null)
            {
                return NotFound();
            }

            return View(tripCatalog);
        }

        // GET: TripCatalogs/Create
        public IActionResult Create()
        {
            ViewData["ID"] = new SelectList(_context.Countries, "ID", "Name");
            ViewData["ID"] = new SelectList(_context.Hotel, "ID", "Name");
            ViewData["ID"] = new SelectList(_context.Town, "ID", "Name");
            ViewData["ID"] = new SelectList(_context.Transport, "ID", "Name");
            ViewData["ID"] = new SelectList(_context.Set<Type_tour>(), "ID", "Name");
            return View();
        }

        // POST: TripCatalogs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Price,CountryID,TownID,TransportID,TypeID,HotelID")] TripCatalog tripCatalog)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tripCatalog);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ID"] = new SelectList(_context.Countries, "ID", "Name", tripCatalog.ID);
            ViewData["ID"] = new SelectList(_context.Hotel, "ID", "Name", tripCatalog.ID);
            ViewData["ID"] = new SelectList(_context.Town, "ID", "Name", tripCatalog.ID);
            ViewData["ID"] = new SelectList(_context.Transport, "ID", "Name", tripCatalog.ID);
            ViewData["ID"] = new SelectList(_context.Set<Type_tour>(), "ID", "Name", tripCatalog.ID);
            return View(tripCatalog);
        }

        // GET: TripCatalogs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tripCatalog = await _context.TripCatalog.FindAsync(id);
            if (tripCatalog == null)
            {
                return NotFound();
            }
            ViewData["ID"] = new SelectList(_context.Countries, "ID", "Name", tripCatalog.ID);
            ViewData["ID"] = new SelectList(_context.Hotel, "ID", "Name", tripCatalog.ID);
            ViewData["ID"] = new SelectList(_context.Town, "ID", "Name", tripCatalog.ID);
            ViewData["ID"] = new SelectList(_context.Transport, "ID", "Name", tripCatalog.ID);
            ViewData["ID"] = new SelectList(_context.Set<Type_tour>(), "ID", "Name", tripCatalog.ID);
            return View(tripCatalog);
        }

        // POST: TripCatalogs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Price,CountryID,TownID,TransportID,TypeID,HotelID")] TripCatalog tripCatalog)
        {
            if (id != tripCatalog.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tripCatalog);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TripCatalogExists(tripCatalog.ID))
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
            ViewData["ID"] = new SelectList(_context.Countries, "ID", "Name", tripCatalog.ID);
            ViewData["ID"] = new SelectList(_context.Hotel, "ID", "Name", tripCatalog.ID);
            ViewData["ID"] = new SelectList(_context.Town, "ID", "Name", tripCatalog.ID);
            ViewData["ID"] = new SelectList(_context.Transport, "ID", "Name", tripCatalog.ID);
            ViewData["ID"] = new SelectList(_context.Set<Type_tour>(), "ID", "Name", tripCatalog.ID);
            return View(tripCatalog);
        }

        // GET: TripCatalogs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tripCatalog = await _context.TripCatalog
                .Include(t => t.Country)
                .Include(t => t.Hotel)
                .Include(t => t.Town)
                .Include(t => t.Transport)
                .Include(t => t.Type_tours)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (tripCatalog == null)
            {
                return NotFound();
            }

            return View(tripCatalog);
        }

        // POST: TripCatalogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tripCatalog = await _context.TripCatalog.FindAsync(id);
            if (tripCatalog != null)
            {
                _context.TripCatalog.Remove(tripCatalog);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TripCatalogExists(int id)
        {
            return _context.TripCatalog.Any(e => e.ID == id);
        }
    }
}
