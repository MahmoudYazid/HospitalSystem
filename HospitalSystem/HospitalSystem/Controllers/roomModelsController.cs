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
    public class roomModelsController : Controller
    {
        private readonly MasterDbContext _context;

        public roomModelsController(MasterDbContext context)
        {
            _context = context;
        }

        // GET: roomModels
        public async Task<IActionResult> Index()
        {
            var masterDbContext = _context.roomDb.Include(r => r.patientModel);
            return View(await masterDbContext.ToListAsync());
        }

        // GET: roomModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomModel = await _context.roomDb
                .Include(r => r.patientModel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (roomModel == null)
            {
                return NotFound();
            }

            return View(roomModel);
        }
        //  
        // GET: roomModels/Create
        public IActionResult Create()
        {
            ViewData["PatientId"] = new SelectList(_context.patientDb.ToList(), "Id", "Name");
            return View();
        }

        // POST: roomModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,statement,type,PatientId")] roomModel roomModel)
        {
           
                _context.Add(roomModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
           
          
        }

        // GET: roomModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomModel = await _context.roomDb.FindAsync(id);
            if (roomModel == null)
            {
                return NotFound();
            }
            ViewData["PatientId"] = new SelectList(_context.patientDb, "Id", "Name", roomModel.PatientId);
            return View(roomModel);
        }

        // POST: roomModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,statement,type,PatientId")] roomModel roomModel)
        {
            if (id != roomModel.Id)
            {
                return NotFound();
            }

        
                try
                {
                    _context.Update(roomModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!roomModelExists(roomModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
          
            ViewData["PatientId"] = new SelectList(_context.patientDb, "Id", "Name", roomModel.PatientId);
            return View(roomModel);
        }

        // GET: roomModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomModel = await _context.roomDb
                .Include(r => r.patientModel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (roomModel == null)
            {
                return NotFound();
            }

            return View(roomModel);
        }

        // POST: roomModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var roomModel = await _context.roomDb.FindAsync(id);
            if (roomModel != null)
            {
                _context.roomDb.Remove(roomModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool roomModelExists(int id)
        {
            return _context.roomDb.Any(e => e.Id == id);
        }
    }
}
