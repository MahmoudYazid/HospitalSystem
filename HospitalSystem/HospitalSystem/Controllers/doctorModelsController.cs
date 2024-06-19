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
    public class doctorModelsController : Controller
    {
        private readonly MasterDbContext _context;

        public doctorModelsController(MasterDbContext context)
        {
            _context = context;
        }

        // GET: doctorModels
        public async Task<IActionResult> Index()
        {
            var masterDbContext = _context.doctorDb.Include(d => d.clinicModel);
            return View(await masterDbContext.ToListAsync());
        }

        // GET: doctorModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctorModel = await _context.doctorDb
                .Include(d => d.clinicModel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (doctorModel == null)
            {
                return NotFound();
            }

            return View(doctorModel);
        }

        // GET: doctorModels/Create
        public IActionResult Create()
        {
            ViewData["clinicID"] = new SelectList(_context.clinicDb, "Id", "Id");
            return View();
        }

        // POST: doctorModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,speciality,name,clinicID")] doctorModel doctorModel)
        {

            _context.doctorDb.Add(doctorModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: doctorModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctorModel = await _context.doctorDb.FindAsync(id);
            if (doctorModel == null)
            {
                return NotFound();
            }
            ViewData["clinicID"] = new SelectList(_context.clinicDb, "Id", "Id", doctorModel.clinicID);
            return View(doctorModel);
        }

        // POST: doctorModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,speciality,name,clinicID")] doctorModel doctorModel)
        {
          
                try
                {
                    _context.Update(doctorModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!doctorModelExists(doctorModel.Id))
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

        // GET: doctorModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctorModel = await _context.doctorDb
                .Include(d => d.clinicModel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (doctorModel == null)
            {
                return NotFound();
            }

            return View(doctorModel);
        }

        // POST: doctorModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var doctorModel = await _context.doctorDb.FindAsync(id);
            if (doctorModel != null)
            {
                _context.doctorDb.Remove(doctorModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool doctorModelExists(int id)
        {
            return _context.doctorDb.Any(e => e.Id == id);
        }
    }
}
