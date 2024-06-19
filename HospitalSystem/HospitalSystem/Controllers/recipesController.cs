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
    public class recipesController : Controller
    {
        private readonly MasterDbContext _context;

        public recipesController(MasterDbContext context)
        {
            _context = context;
        }

        // GET: recipes
        public async Task<IActionResult> Index()
        {
            var masterDbContext = _context.recipesDb.Include(r => r.doctorModel).Include(r => r.patientModel);
            return View(await masterDbContext.ToListAsync());
        }

        // GET: recipes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipe = await _context.recipesDb
                .Include(r => r.doctorModel)
                .Include(r => r.patientModel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recipe == null)
            {
                return NotFound();
            }

            return View(recipe);
        }

        // GET: recipes/Create
        public IActionResult Create()
        {
            ViewData["DoctorId"] = new SelectList(_context.doctorDb, "Id", "name");
            ViewData["PatientId"] = new SelectList(_context.patientDb, "Id", "Id");
            return View();
        }

        // POST: recipes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DoctorId,PatientId,time,drugs")] recipe recipe)
        {
          
                _context.Add(recipe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
           
          
        }

        // GET: recipes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipe = await _context.recipesDb.FindAsync(id);
            if (recipe == null)
            {
                return NotFound();
            }
            ViewData["DoctorId"] = new SelectList(_context.doctorDb, "Id", "name", recipe.DoctorId);
            ViewData["PatientId"] = new SelectList(_context.patientDb, "Id", "Id", recipe.PatientId);
            return View(recipe);
        }

        // POST: recipes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DoctorId,PatientId,time,drugs")] recipe recipe)
        {
            if (id != recipe.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(recipe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!recipeExists(recipe.Id))
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
            ViewData["DoctorId"] = new SelectList(_context.doctorDb, "Id", "name", recipe.DoctorId);
            ViewData["PatientId"] = new SelectList(_context.patientDb, "Id", "Id", recipe.PatientId);
            return View(recipe);
        }

        // GET: recipes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipe = await _context.recipesDb
                .Include(r => r.doctorModel)
                .Include(r => r.patientModel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recipe == null)
            {
                return NotFound();
            }

            return View(recipe);
        }

        // POST: recipes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var recipe = await _context.recipesDb.FindAsync(id);
            if (recipe != null)
            {
                _context.recipesDb.Remove(recipe);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool recipeExists(int id)
        {
            return _context.recipesDb.Any(e => e.Id == id);
        }
    }
}
