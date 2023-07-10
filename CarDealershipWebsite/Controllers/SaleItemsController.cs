using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarDealershipWebsite.Areas.Identity.Data;
using CarDealershipWebsite.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace CarDealershipWebsite.Controllers
{
    [Authorize(Roles = "Admin")]

    public class SaleItemsController : Controller
    {
        private readonly CarDealershipWebsiteContext _context;

        public SaleItemsController(CarDealershipWebsiteContext context)
        {
            _context = context;
        }

        // GET: SaleItems
        public async Task<IActionResult> Index()
        {
            var carDealershipWebsiteContext = _context.SaleItems.Include(s => s.Sale).Include(s => s.Stock);
            return View(await carDealershipWebsiteContext.ToListAsync());
        }

        // GET: SaleItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SaleItems == null)
            {
                return NotFound();
            }

            var saleItem = await _context.SaleItems
                .Include(s => s.Sale)
                .Include(s => s.Stock)
                .FirstOrDefaultAsync(m => m.SaleItemID == id);
            if (saleItem == null)
            {
                return NotFound();
            }

            return View(saleItem);
        }

        // GET: SaleItems/Create
        public IActionResult Create()
        {
            ViewData["SaleId"] = new SelectList(_context.Sales, "SaleID", "SaleID");
            ViewData["CarsStockId"] = new SelectList(_context.CarsStocks, "StockID", "StockID");
            return View();
        }

        // POST: SaleItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SaleItemID,SaleId,CarsStockId")] SaleItem saleItem)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(saleItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SaleId"] = new SelectList(_context.Sales, "SaleID", "SaleID", saleItem.SaleId);
            ViewData["CarsStockId"] = new SelectList(_context.CarsStocks, "StockID", "StockID", saleItem.CarsStockId);
            return View(saleItem);
        }

        // GET: SaleItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SaleItems == null)
            {
                return NotFound();
            }

            var saleItem = await _context.SaleItems.FindAsync(id);
            if (saleItem == null)
            {
                return NotFound();
            }
            ViewData["SaleId"] = new SelectList(_context.Sales, "SaleID", "SaleID", saleItem.SaleId);
            ViewData["CarsStockId"] = new SelectList(_context.CarsStocks, "StockID", "StockID", saleItem.CarsStockId);
            return View(saleItem);
        }

        // POST: SaleItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SaleItemID,SaleId,CarsStockId")] SaleItem saleItem)
        {
            if (id != saleItem.SaleItemID)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(saleItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SaleItemExists(saleItem.SaleItemID))
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
            ViewData["SaleId"] = new SelectList(_context.Sales, "SaleID", "SaleID", saleItem.SaleId);
            ViewData["CarsStockId"] = new SelectList(_context.CarsStocks, "StockID", "StockID", saleItem.CarsStockId);
            return View(saleItem);
        }

        // GET: SaleItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SaleItems == null)
            {
                return NotFound();
            }

            var saleItem = await _context.SaleItems
                .Include(s => s.Sale)
                .Include(s => s.Stock)
                .FirstOrDefaultAsync(m => m.SaleItemID == id);
            if (saleItem == null)
            {
                return NotFound();
            }

            return View(saleItem);
        }

        // POST: SaleItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SaleItems == null)
            {
                return Problem("Entity set 'CarDealershipWebsiteContext.SaleItems'  is null.");
            }
            var saleItem = await _context.SaleItems.FindAsync(id);
            if (saleItem != null)
            {
                _context.SaleItems.Remove(saleItem);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SaleItemExists(int id)
        {
          return (_context.SaleItems?.Any(e => e.SaleItemID == id)).GetValueOrDefault();
        }
    }
}
