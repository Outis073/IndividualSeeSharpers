using IndividualSeeSharpers.Models;

namespace IndividualSeeSharpers.Services;

public interface IMailService
{
    Task SendEmailAsync(MailRequest mailRequest);
}