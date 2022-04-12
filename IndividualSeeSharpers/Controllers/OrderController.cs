using System.Diagnostics;
using System.Numerics;
using IndividualSeeSharpers.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IndividualSeeSharpers.Data;
using IndividualSeeSharpers.Helpers;
using IndividualSeeSharpers.Models;
using IndividualSeeSharpers.Services.SeatService;


namespace IndividualSeeSharpers.Controllers;

public class OrderController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly SeeSharpersContext _context;

    public OrderController(SeeSharpersContext context, ILogger<HomeController> logger)
    {
        _context = context;
        _logger = logger;
    }

    public IActionResult Index(string reservedSeats, int id)
    {
        Show? show;
        try
        {
            show = GetViewing(id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return Redirect("/Home");
        }

        if (show == null)
            return Redirect("/Home");

        SeatService service = new(show, _context);

        var seatPositions = SeatPositionHelper.DeserializePositionToVector2List(reservedSeats);

        ViewBag.Seats = service.GetSeats(seatPositions).ToArray();
        return View(show);
    }

    private Show? GetViewing(int id)
    {
        try
        {
            return _context.Shows
                .Include(v => v.Theatre)
                .Include(v => v.ShowSeats)
                .Include(v => v.Movie)
                .First(s => s.Id == id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}