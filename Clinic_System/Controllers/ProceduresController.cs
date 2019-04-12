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
    public class ProceduresController : Controller
    {
        private readonly ClinicContext _context;

        public ProceduresController(ClinicContext context)
        {
            _context = context;
        }

        // GET: Procedures
        public async Task<IActionResult> Index()
        {
            return View(await _context.Procedure.ToListAsync());
        }

        // GET: Procedures/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var procedure = await _context.Procedure
                .FirstOrDefaultAsync(m => m.ProcedureID == id);
            if (procedure == null)
            {
                return NotFound();
            }

            return View(procedure);
        }

        // GET: Procedures/Create
        public IActionResult Create()
        {

            PopulatePatientsDropDownList();
            PopulatePractitionersDropDownList();
            return View();
        }

        // POST: Procedures/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProcedureID,PractitionerID,PatientID,Medication,Complication,ProcedureUsed")] Procedure procedure)
        {
            if (ModelState.IsValid)
            {
                _context.Add(procedure);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(procedure);
        }

        // GET: Procedures/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var procedure = await _context.Procedure.FindAsync(id);
            if (procedure == null)
            {
                return NotFound();
            }
            return View(procedure);
        }

        // POST: Procedures/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProcedureID,PractitionerID,PatientID,Medication,Complication,ProcedureUsed")] Procedure procedure)
        {
            if (id != procedure.ProcedureID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(procedure);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProcedureExists(procedure.ProcedureID))
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
            return View(procedure);
        }

        // GET: Procedures/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var procedure = await _context.Procedure
                .FirstOrDefaultAsync(m => m.ProcedureID == id);
            if (procedure == null)
            {
                return NotFound();
            }

            return View(procedure);
        }

        // POST: Procedures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var procedure = await _context.Procedure.FindAsync(id);
            _context.Procedure.Remove(procedure);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProcedureExists(int id)
        {
            return _context.Procedure.Any(e => e.ProcedureID == id);
        }

        private void PopulatePatientsDropDownList(object selectedPatient = null)
        {
            var PatientsQuery = from d in _context.Patients
                                orderby d.PatientFirstname
                                select d;
            ViewBag.PatientID = new SelectList(PatientsQuery.AsNoTracking(), "PatientID", "PatientFirstname", selectedPatient);
        }

        private void PopulatePractitionersDropDownList(object selectedPractitioner = null)
        {
            var PractitionersQuery = from d in _context.Practitioners
                                     orderby d.Username
                                     select d;
            ViewBag.PractitionerID = new SelectList(PractitionersQuery.AsNoTracking(), "PractitionerID", "Username", selectedPractitioner);
        }
    }
}
