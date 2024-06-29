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
    public class reportsModelsController : Controller
    {
        private readonly MasterDbContext _context;

        public reportsModelsController(MasterDbContext context)
        {
            _context = context;
        }

        // GET: reportsModels
        public async Task<IActionResult> Index()
        {
            var masterDbContext = _context.reportsDb.Include(r => r.doctorModel).Include(r => r.patientModel);
            return View(await masterDbContext.ToListAsync());
        }

        // GET: reportsModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reportsModel = await _context.reportsDb
                .Include(r => r.doctorModel)
                .Include(r => r.patientModel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reportsModel == null)
            {
                return NotFound();
            }

            return View(reportsModel);
        }

        // GET: reportsModels/Create
        public IActionResult Create()
        {
            ViewData["DoctorId"] = new SelectList(_context.doctorDb, "Id", "name");
            ViewData["PatientId"] = new SelectList(_context.patientDb, "Id", "Name");
            return View();
        }

        // POST: reportsModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DoctorId,PatientId,time,report")] reportsModel reportsModel)
        {
         
                _context.Add(reportsModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
          
        }

        // GET: reportsModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reportsModel = await _context.reportsDb.FindAsync(id);
            if (reportsModel == null)
            {
                return NotFound();
            }
            ViewData["DoctorId"] = new SelectList(_context.doctorDb, "Id", "name", reportsModel.DoctorId);
            ViewData["PatientId"] = new SelectList(_context.patientDb, "Id", "Name", reportsModel.PatientId);
            return View(reportsModel);
        }

        // POST: reportsModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DoctorId,PatientId,time,report")] reportsModel reportsModel)
        {
            if (id != reportsModel.Id)
            {
                return NotFound();
            }

         
                try
                {
                    _context.Update(reportsModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!reportsModelExists(reportsModel.Id))
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

        // GET: reportsModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reportsModel = await _context.reportsDb
                .Include(r => r.doctorModel)
                .Include(r => r.patientModel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reportsModel == null)
            {
                return NotFound();
            }

            return View(reportsModel);
        }

        // POST: reportsModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reportsModel = await _context.reportsDb.FindAsync(id);
            if (reportsModel != null)
            {
                _context.reportsDb.Remove(reportsModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool reportsModelExists(int id)
        {
            return _context.reportsDb.Any(e => e.Id == id);
        }
    }
}
