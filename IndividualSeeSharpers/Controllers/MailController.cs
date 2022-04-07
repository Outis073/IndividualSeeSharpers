using IndividualSeeSharpers.Models;
using IndividualSeeSharpers.Services;
using Microsoft.AspNetCore.Mvc;

namespace IndividualSeeSharpers.Controllers
{
    public class MailController : Controller
    {
        private readonly IMailService mailService;
        public MailController(IMailService mailService)
        {
            this.mailService = mailService;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }
        [HttpPost("send")]
        public async Task<IActionResult> SendMail([Bind("ToEmail, Subject, Body, Attachments")] MailRequest request)
        {
            try
            {
                await mailService.SendEmailAsync(request);
                return Ok();
            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}
