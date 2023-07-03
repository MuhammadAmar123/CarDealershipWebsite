using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarDealershipWebsite.Areas.Identity.Data;
using CarDealershipWebsite.Models;

namespace CarDealershipWebsite.Controllers
{
    public class CarsStocksController : Controller
    {
        private readonly CarDealershipWebsiteContext _context;

        public CarsStocksController(CarDealershipWebsiteContext context)
        {
            _context = context;
        }

        // GET: CarsStocks
        public async Task<IActionResult> Index()
        {
            var carDealershipWebsiteContext = _context.CarsStocks.Include(c => c.Model).Include(c => c.Store);
            return View(await carDealershipWebsiteContext.ToListAsync());
        }

        // GET: CarsStocks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CarsStocks == null)
            {
                return NotFound();
            }

            var carsStock = await _context.CarsStocks
                .Include(c => c.Model)
                .Include(c => c.Store)
                .FirstOrDefaultAsync(m => m.StockID == id);
            if (carsStock == null)
            {
                return NotFound();
            }

            return View(carsStock);
        }

        // GET: CarsStocks/Create
        public IActionResult Create()
        {
            ViewData["CarsModelId"] = new SelectList(_context.CarsModels, "ModelID", "ModelID");
            ViewData["StoreId"] = new SelectList(_context.Stores, "StoreID", "StoreID");
            return View();
        }

        // POST: CarsStocks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StockID,CarsModelId,Year,Mileage,Sold,Price,StoreId,LicensePlate")] CarsStock carsStock)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(carsStock);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarsModelId"] = new SelectList(_context.CarsModels, "ModelID", "ModelID", carsStock.CarsModelId);
            ViewData["StoreId"] = new SelectList(_context.Stores, "StoreID", "StoreID", carsStock.StoreId);
            return View(carsStock);
        }

        // GET: CarsStocks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CarsStocks == null)
            {
                return NotFound();
            }

            var carsStock = await _context.CarsStocks.FindAsync(id);
            if (carsStock == null)
            {
                return NotFound();
            }
            ViewData["CarsModelId"] = new SelectList(_context.CarsModels, "ModelID", "ModelID", carsStock.CarsModelId);
            ViewData["StoreId"] = new SelectList(_context.Stores, "StoreID", "StoreID", carsStock.StoreId);
            return View(carsStock);
        }

        // POST: CarsStocks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StockID,CarsModelId,Year,Mileage,Sold,Price,StoreId,LicensePlate")] CarsStock carsStock)
        {
            if (id != carsStock.StockID)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(carsStock);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarsStockExists(carsStock.StockID))
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
            ViewData["CarsModelId"] = new SelectList(_context.CarsModels, "ModelID", "ModelID", carsStock.CarsModelId);
            ViewData["StoreId"] = new SelectList(_context.Stores, "StoreID", "StoreID", carsStock.StoreId);
            return View(carsStock);
        }

        // GET: CarsStocks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CarsStocks == null)
            {
                return NotFound();
            }

            var carsStock = await _context.CarsStocks
                .Include(c => c.Model)
                .Include(c => c.Store)
                .FirstOrDefaultAsync(m => m.StockID == id);
            if (carsStock == null)
            {
                return NotFound();
            }

            return View(carsStock);
        }

        // POST: CarsStocks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CarsStocks == null)
            {
                return Problem("Entity set 'CarDealershipWebsiteContext.CarsStocks'  is null.");
            }
            var carsStock = await _context.CarsStocks.FindAsync(id);
            if (carsStock != null)
            {
                _context.CarsStocks.Remove(carsStock);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarsStockExists(int id)
        {
          return (_context.CarsStocks?.Any(e => e.StockID == id)).GetValueOrDefault();
        }
    }
}
