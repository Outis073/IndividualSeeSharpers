using IndividualSeeSharpers.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IndividualSeeSharpers.ViewModels;

public class MailSubscriberViewModel
{
    public IEnumerable<Subscriber>? Subscriber { get; set; }

    public MailRequest? MailRequest { get; set; }

}