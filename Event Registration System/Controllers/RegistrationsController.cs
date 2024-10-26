using Event_Registration_System.Data;
using Event_Registration_System.Models;
using Event_Registration_System.Services;
using Microsoft.AspNetCore.Mvc;

namespace Event_Registration_System.Controllers
{
    public class RegistrationsController : Controller
    {
        private readonly EventRegistrationDbContext _context;
        private readonly EmailService _emailService;

        public RegistrationsController(EventRegistrationDbContext context, EmailService emailService)
        {
            _context = context;
            _emailService = emailService;
        }

        [HttpGet]
        public async Task<IActionResult> Register(int eventId)
        {
            var eventEntity = await _context.Events.FindAsync(eventId);
            if (eventEntity == null) return NotFound();

            ViewBag.EventTitle = eventEntity.Title;
            return View(new Registration { EventId = eventId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(Registration registration)
        {
            if (ModelState.IsValid)
            {
                _context.Registrations.Add(registration);
                await _context.SaveChangesAsync();

                var eventEntity = await _context.Events.FindAsync(registration.EventId);
                await _emailService.SendConfirmationEmailAsync(registration.Email, registration.ParticipantName, eventEntity.Title);

                return RedirectToAction("Confirmation");
            }
            return View(registration);
        }

        public IActionResult Confirmation()
        {
            return View();
        }
    }

}
