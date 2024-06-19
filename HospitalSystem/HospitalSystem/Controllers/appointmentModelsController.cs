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
    public class appointmentModelsController : Controller
    {
        private readonly MasterDbContext _context;

        public appointmentModelsController(MasterDbContext context)
        {
            _context = context;
        }

        // GET: appointmentModels
        public async Task<IActionResult> Index()
        {
            var masterDbContext = _context.appointmentDb.Include(a => a.doctorModel).Include(a => a.patientModel);
            return View(await masterDbContext.ToListAsync());
        }

        // GET: appointmentModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointmentModel = await _context.appointmentDb
                .Include(a => a.doctorModel)
                .Include(a => a.patientModel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (appointmentModel == null)
            {
                return NotFound();
            }

            return View(appointmentModel);
        }

        // GET: appointmentModels/Create
        public IActionResult Create()
        {
            ViewData["DoctorId"] = new SelectList(_context.doctorDb, "Id", "name");
            ViewData["PatientId"] = new SelectList(_context.patientDb, "Id", "Id");
            return View();
        }

        // POST: appointmentModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DoctorId,PatientId,status,time")] appointmentModel appointmentModel)
        {
                _context.Add(appointmentModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
          
        }

        // GET: appointmentModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointmentModel = await _context.appointmentDb.FindAsync(id);
            if (appointmentModel == null)
            {
                return NotFound();
            }
            ViewData["DoctorId"] = new SelectList(_context.doctorDb, "Id", "name", appointmentModel.DoctorId);
            ViewData["PatientId"] = new SelectList(_context.patientDb, "Id", "Id", appointmentModel.PatientId);
            return View(appointmentModel);
        }

        // POST: appointmentModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DoctorId,PatientId,status,time")] appointmentModel appointmentModel)
        {
            if (id != appointmentModel.Id)
            {
                return NotFound();
            }

          
                try
                {
                    _context.Update(appointmentModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!appointmentModelExists(appointmentModel.Id))
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

        // GET: appointmentModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointmentModel = await _context.appointmentDb
                .Include(a => a.doctorModel)
                .Include(a => a.patientModel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (appointmentModel == null)
            {
                return NotFound();
            }

            return View(appointmentModel);
        }

        // POST: appointmentModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var appointmentModel = await _context.appointmentDb.FindAsync(id);
            if (appointmentModel != null)
            {
                _context.appointmentDb.Remove(appointmentModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool appointmentModelExists(int id)
        {
            return _context.appointmentDb.Any(e => e.Id == id);
        }
    }
}
