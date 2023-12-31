﻿using System;
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

    public class TransmissionsController : Controller
    {
        private readonly CarDealershipWebsiteContext _context;

        public TransmissionsController(CarDealershipWebsiteContext context)
        {
            _context = context;
        }

        // GET: Transmissions
        public async Task<IActionResult> Index()
        {
              return _context.Transmissions != null ? 
                          View(await _context.Transmissions.ToListAsync()) :
                          Problem("Entity set 'CarDealershipWebsiteContext.Transmissions'  is null.");
        }

        // GET: Transmissions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Transmissions == null)
            {
                return NotFound();
            }

            var transmission = await _context.Transmissions
                .FirstOrDefaultAsync(m => m.TransmissionID == id);
            if (transmission == null)
            {
                return NotFound();
            }

            return View(transmission);
        }

        // GET: Transmissions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Transmissions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TransmissionID,TransmissionName")] Transmission transmission)
        {
            if (ModelState.IsValid)
            {
                _context.Add(transmission);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(transmission);
        }

        // GET: Transmissions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Transmissions == null)
            {
                return NotFound();
            }

            var transmission = await _context.Transmissions.FindAsync(id);
            if (transmission == null)
            {
                return NotFound();
            }
            return View(transmission);
        }

        // POST: Transmissions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TransmissionID,TransmissionName")] Transmission transmission)
        {
            if (id != transmission.TransmissionID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transmission);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransmissionExists(transmission.TransmissionID))
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
            return View(transmission);
        }

        // GET: Transmissions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Transmissions == null)
            {
                return NotFound();
            }

            var transmission = await _context.Transmissions
                .FirstOrDefaultAsync(m => m.TransmissionID == id);
            if (transmission == null)
            {
                return NotFound();
            }

            return View(transmission);
        }

        // POST: Transmissions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Transmissions == null)
            {
                return Problem("Entity set 'CarDealershipWebsiteContext.Transmissions'  is null.");
            }
            var transmission = await _context.Transmissions.FindAsync(id);
            if (transmission != null)
            {
                _context.Transmissions.Remove(transmission);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransmissionExists(int id)
        {
          return (_context.Transmissions?.Any(e => e.TransmissionID == id)).GetValueOrDefault();
        }
    }
}
