using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HospitalSystem.Models.databaseModels;

namespace HospitalSystem.Controllers
{
    public class ClinicModelsController : Controller
    {
        private readonly MasterDbContext _context;

        public ClinicModelsController(MasterDbContext context)
        {
            _context = context;
        }

        // GET: ClinicModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.clinicDb.ToListAsync());
        }

        // GET: ClinicModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clinicModel = await _context.clinicDb
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clinicModel == null)
            {
                return NotFound();
            }

            return View(clinicModel);
        }

        // GET: ClinicModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ClinicModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,name,speciality")] ClinicModel clinicModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clinicModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clinicModel);
        }

        // GET: ClinicModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clinicModel = await _context.clinicDb.FindAsync(id);
            if (clinicModel == null)
            {
                return NotFound();
            }
            return View(clinicModel);
        }

        // POST: ClinicModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,name,speciality")] ClinicModel clinicModel)
        {
            if (id != clinicModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clinicModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClinicModelExists(clinicModel.Id))
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
            return View(clinicModel);
        }

        // GET: ClinicModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clinicModel = await _context.clinicDb
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clinicModel == null)
            {
                return NotFound();
            }

            return View(clinicModel);
        }

        // POST: ClinicModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clinicModel = await _context.clinicDb.FindAsync(id);
            if (clinicModel != null)
            {
                _context.clinicDb.Remove(clinicModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClinicModelExists(int id)
        {
            return _context.clinicDb.Any(e => e.Id == id);
        }
    }
}
