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
    public class roomWaitingListModelsController : Controller
    {
        private readonly MasterDbContext _context;

        public roomWaitingListModelsController(MasterDbContext context)
        {
            _context = context;
        }

        // GET: roomWaitingListModels
        public async Task<IActionResult> Index()
        {
            var masterDbContext = _context.roomWaitingListDb.Include(r => r.patientModel);
            return View(await masterDbContext.ToListAsync());
        }

        // GET: roomWaitingListModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomWaitingListModel = await _context.roomWaitingListDb
                .Include(r => r.patientModel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (roomWaitingListModel == null)
            {
                return NotFound();
            }

            return View(roomWaitingListModel);
        }

        // GET: roomWaitingListModels/Create
        public IActionResult Create()
        {
            ViewData["PatientId"] = new SelectList(_context.patientDb, "Id", "Name");
            return View();
        }

        // POST: roomWaitingListModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,time,PatientId")] roomWaitingListModel roomWaitingListModel)
        {
          
                _context.Add(roomWaitingListModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
          
        }

        // GET: roomWaitingListModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomWaitingListModel = await _context.roomWaitingListDb.FindAsync(id);
            if (roomWaitingListModel == null)
            {
                return NotFound();
            }
            ViewData["PatientId"] = new SelectList(_context.patientDb, "Id", "Name", roomWaitingListModel.PatientId);
            return View(roomWaitingListModel);
        }

        // POST: roomWaitingListModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,time,PatientId")] roomWaitingListModel roomWaitingListModel)
        {
            if (id != roomWaitingListModel.Id)
            {
                return NotFound();
            }

        
                try
                {
                    _context.Update(roomWaitingListModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!roomWaitingListModelExists(roomWaitingListModel.Id))
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

        // GET: roomWaitingListModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomWaitingListModel = await _context.roomWaitingListDb
                .Include(r => r.patientModel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (roomWaitingListModel == null)
            {
                return NotFound();
            }

            return View(roomWaitingListModel);
        }

        // POST: roomWaitingListModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var roomWaitingListModel = await _context.roomWaitingListDb.FindAsync(id);
            if (roomWaitingListModel != null)
            {
                _context.roomWaitingListDb.Remove(roomWaitingListModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool roomWaitingListModelExists(int id)
        {
            return _context.roomWaitingListDb.Any(e => e.Id == id);
        }
    }
}
