using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Clinic_System.Data;
using Clinic_System.Models;

namespace Clinic_System.Controllers
{
    public class PractitionersController : Controller
    {
        private readonly ClinicContext _context;

        public PractitionersController(ClinicContext context)
        {
            _context = context;
        }

        // GET: Practitioners
        public async Task<IActionResult> Index()
        {
            return View(await _context.Practitioners.ToListAsync());
        }

        // GET: Practitioners/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var practitioner = await _context.Practitioners
                .FirstOrDefaultAsync(m => m.PractitionerID == id);
            if (practitioner == null)
            {
                return NotFound();
            }

            return View(practitioner);
        }

        // GET: Practitioners/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Practitioners/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PractitionerID,Username,Password,Email,Type,ContactNo")] Practitioner practitioner)
        {
            if (ModelState.IsValid)
            {
                _context.Add(practitioner);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(practitioner);
        }

        // GET: Practitioners/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var practitioner = await _context.Practitioners.FindAsync(id);
            if (practitioner == null)
            {
                return NotFound();
            }
            return View(practitioner);
        }

        // POST: Practitioners/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PractitionerID,Username,Password,Email,Type,ContactNo")] Practitioner practitioner)
        {
            if (id != practitioner.PractitionerID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(practitioner);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PractitionerExists(practitioner.PractitionerID))
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
            return View(practitioner);
        }

        // GET: Practitioners/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var practitioner = await _context.Practitioners
                .FirstOrDefaultAsync(m => m.PractitionerID == id);
            if (practitioner == null)
            {
                return NotFound();
            }

            return View(practitioner);
        }

        // POST: Practitioners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var practitioner = await _context.Practitioners.FindAsync(id);
            _context.Practitioners.Remove(practitioner);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PractitionerExists(int id)
        {
            return _context.Practitioners.Any(e => e.PractitionerID == id);
        }
    }
}
