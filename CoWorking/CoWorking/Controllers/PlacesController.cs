using CoWorking.Data;
using CoWorking.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoWorking.Controllers
{
    public class PlacesController : Controller
    {
        private readonly DataContext _context;

        public PlacesController(DataContext context)
        {
            _context = context;
        }

       
        public async Task<IActionResult> Index()
        {
            return View(await _context.Places.ToListAsync());
        }

        
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Places == null)
            {
                return NotFound();
            }

            var place = await _context.Places
                .FirstOrDefaultAsync(m => m.Id == id);
            if (place == null)
            {
                return NotFound();
            }

            return View(place);
        }

        
        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( Place place)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(place);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Ya existe un edificio con ese nombre.");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
                    }
                }
                catch (Exception exception)
                {
                    ModelState.AddModelError(string.Empty, exception.Message);
                }
            }
            return View(place);
        }

       
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Places == null)
            {
                return NotFound();
            }

            var place = await _context.Places.FindAsync(id);
            if (place == null)
            {
                return NotFound();
            }
            return View(place);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,  Place place)
        {
            if (id != place.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(place);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Ya existe una empresa con ese nombre.");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
                    }
                }
                catch (Exception exception)
                {
                    ModelState.AddModelError(string.Empty, exception.Message);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(place);
        }

        
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Places == null)
            {
                return NotFound();
            }

            var place = await _context.Places
                .FirstOrDefaultAsync(m => m.Id == id);
            if (place == null)
            {
                return NotFound();
            }

            return View(place);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Places == null)
            {
                return Problem("Entity set 'DataContext.Places'  is null.");
            }
            var place = await _context.Places.FindAsync(id);
            if (place != null)
            {
                _context.Places.Remove(place);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    
    }
}
