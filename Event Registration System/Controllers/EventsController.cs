using Event_Registration_System.Data;
using Event_Registration_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Event_Registration_System.Controllers
{
    public class EventsController : Controller
    {
        private readonly EventRegistrationDbContext _context;

        public EventsController(EventRegistrationDbContext context)
        {
            _context = context;
        }

        // List all events
        public async Task<IActionResult> Index()
        {
            return View(await _context.Events.ToListAsync());
        }

        // Display event details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var eventEntity = await _context.Events.FindAsync(id);
            if (eventEntity == null) return NotFound();

            return View(eventEntity);
        }

        // Create a new event
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Event eventEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eventEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(eventEntity);
        }

        // Edit an event
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var eventEntity = await _context.Events.FindAsync(id);
            if (eventEntity == null) return NotFound();

            return View(eventEntity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Event eventEntity)
        {
            if (id != eventEntity.Id) return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(eventEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(eventEntity);
        }

        // Delete an event
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var eventEntity = await _context.Events.FindAsync(id);
            if (eventEntity == null) return NotFound();

            return View(eventEntity);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var eventEntity = await _context.Events.FindAsync(id);
            _context.Events.Remove(eventEntity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }

}
