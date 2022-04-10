using IndividualSeeSharpers.Models;
using Microsoft.AspNetCore.Mvc;

namespace IndividualSeeSharpers.Controllers
{
    public class SubscribeController : Controller
    {
        private readonly SeeSharpersContext _context;

        public SubscribeController(SeeSharpersContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Subscribe (string email)
        {
            if (ModelState.IsValid)
            {
                var subresult = _context.Subscribers.FirstOrDefault(x => x.Email == email);
                if (subresult != null)
                {
                    return View("Exists");
                }
                
                _context.Add(new Subscriber() { Email = email});
                await _context.SaveChangesAsync();
                return View("Succes");

            }

            return View("Failed");
        }
    }
}
