using IndividualSeeSharpers.Models;
using IndividualSeeSharpers.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IndividualSeeSharpers.Controllers
{
    public class MailController : Controller
    {
        private readonly IMailService _mailService;
        private readonly SeeSharpersContext _context;

        public MailController(IMailService mailService, SeeSharpersContext context)
        {
            _mailService = mailService;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["Subscribers"] = new SelectList(_context.Subscribers, "Email", "Email");
            return View();
        }

        

        [HttpPost("send")]
        public async Task<IActionResult> MailNewsletter(MailRequest request)
        {

            var mailingList = from m in _context.Subscribers
                select m;
            foreach (var member in mailingList)
            {
                MailRequest mailRequest = new()
                {
                    ToEmail = member.Email,
                    Subject = request.Subject,
                    Body = request.Body,
                    Attachments = request.Attachments
                };
                await _mailService.SendEmailAsync(mailRequest);
            }

            return Ok();

        }
    }
}
