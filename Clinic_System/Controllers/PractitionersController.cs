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
        public async Task<IActionResult> Index(string sortOrder, string searchString, string currentFilter, int? page)
        {



            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "username" : "";
            ViewData["LastnameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "email" : "";
            ViewData["UsernameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "type" : "";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var practitioners = from p in _context.Practitioners
                           select p;

            if (!String.IsNullOrEmpty(searchString))
            {
                practitioners = practitioners.Where(p => p.Username.Contains(searchString)
                    || p.Email.Contains(searchString)
                    || p.Type.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "username":
                    practitioners = practitioners.OrderByDescending(p => p.Username);
                    break;
                case "email":
                    practitioners = practitioners.OrderByDescending(p => p.Email);
                    break;
                case "type":
                    practitioners = practitioners.OrderByDescending(p => p.Type);
                    break;
                default:
                    practitioners = practitioners.OrderBy(p => p.Type);
                    break;
            }
            int pageSize = 3;



            //return View(await _context.Practitioners.ToListAsync());
            return View(await PaginatedList<Practitioner>.CreateAsync(practitioners.AsNoTracking(), page ?? 1, pageSize));
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
