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
    public class CarsModelsController : Controller
    {
        private readonly CarDealershipWebsiteContext _context;

        public CarsModelsController(CarDealershipWebsiteContext context)
        {
            _context = context;
        }

        // GET: CarsModels
        public async Task<IActionResult> Index()
        {
            var carDealershipWebsiteContext = _context.CarsModels.Include(c => c.Brand).Include(c => c.FuelType).Include(c => c.Transmission);
            return View(await carDealershipWebsiteContext.ToListAsync());
        }

        // GET: CarsModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CarsModels == null)
            {
                return NotFound();
            }

            var carsModel = await _context.CarsModels
                .Include(c => c.Brand)
                .Include(c => c.FuelType)
                .Include(c => c.Transmission)
                .FirstOrDefaultAsync(m => m.ModelID == id);
            if (carsModel == null)
            {
                return NotFound();
            }

            return View(carsModel);
        }

        // GET: CarsModels/Create
        public IActionResult Create()
        {
            ViewData["BrandId"] = new SelectList(_context.Brands, "BrandID", "BrandID");
            ViewData["FuelId"] = new SelectList(_context.Fuels, "FuelID", "FuelID");
            ViewData["TransmissionId"] = new SelectList(_context.Transmissions, "TransmissionID", "TransmissionID");
            return View();
        }

        // POST: CarsModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ModelID,BrandId,Model,Seats,EngineSize,TransmissionId,FuelId,Drivetrain")] CarsModel carsModel)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(carsModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BrandId"] = new SelectList(_context.Brands, "BrandID", "BrandID", carsModel.BrandId);
            ViewData["FuelId"] = new SelectList(_context.Fuels, "FuelID", "FuelID", carsModel.FuelId);
            ViewData["TransmissionId"] = new SelectList(_context.Transmissions, "TransmissionID", "TransmissionID", carsModel.TransmissionId);
            return View(carsModel);
        }

        // GET: CarsModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CarsModels == null)
            {
                return NotFound();
            }

            var carsModel = await _context.CarsModels.FindAsync(id);
            if (carsModel == null)
            {
                return NotFound();
            }
            ViewData["BrandId"] = new SelectList(_context.Brands, "BrandID", "BrandID", carsModel.BrandId);
            ViewData["FuelId"] = new SelectList(_context.Fuels, "FuelID", "FuelID", carsModel.FuelId);
            ViewData["TransmissionId"] = new SelectList(_context.Transmissions, "TransmissionID", "TransmissionID", carsModel.TransmissionId);
            return View(carsModel);
        }

        // POST: CarsModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ModelID,BrandId,Model,Seats,EngineSize,TransmissionId,FuelId,Drivetrain")] CarsModel carsModel)
        {
            if (id != carsModel.ModelID)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(carsModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarsModelExists(carsModel.ModelID))
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
            ViewData["BrandId"] = new SelectList(_context.Brands, "BrandID", "BrandID", carsModel.BrandId);
            ViewData["FuelId"] = new SelectList(_context.Fuels, "FuelID", "FuelID", carsModel.FuelId);
            ViewData["TransmissionId"] = new SelectList(_context.Transmissions, "TransmissionID", "TransmissionID", carsModel.TransmissionId);
            return View(carsModel);
        }

        // GET: CarsModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CarsModels == null)
            {
                return NotFound();
            }

            var carsModel = await _context.CarsModels
                .Include(c => c.Brand)
                .Include(c => c.FuelType)
                .Include(c => c.Transmission)
                .FirstOrDefaultAsync(m => m.ModelID == id);
            if (carsModel == null)
            {
                return NotFound();
            }

            return View(carsModel);
        }

        // POST: CarsModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CarsModels == null)
            {
                return Problem("Entity set 'CarDealershipWebsiteContext.CarsModels'  is null.");
            }
            var carsModel = await _context.CarsModels.FindAsync(id);
            if (carsModel != null)
            {
                _context.CarsModels.Remove(carsModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarsModelExists(int id)
        {
          return (_context.CarsModels?.Any(e => e.ModelID == id)).GetValueOrDefault();
        }
    }
}
