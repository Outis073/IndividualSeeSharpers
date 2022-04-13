using IndividualSeeSharpers.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IndividualSeeSharpers.Helpers;
using IndividualSeeSharpers.Services.SeatService;

namespace IndividualSeeSharpers.Controllers
{
    public class SeatSelectionController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SeeSharpersContext _context;

        public SeatSelectionController(SeeSharpersContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public Task<IActionResult> Index(int id)
        {
            Show? show;
            try
            {
                show = GetShow(id);
            }
            catch (Exception e)
            {
                return Task.FromResult<IActionResult>(View());
            }

            if (show == null) 
            {

                return Task.FromResult<IActionResult>(View());

            }

            SeatService seatService = new(show, _context);
            ViewBag.Rows = seatService.GetSeatsOrderedByNumber();

            return Task.FromResult<IActionResult>(View(show));
        }

        public IActionResult save(int id)
        {
            Show? show;
            try
            {
                show = GetShow(id);
            }
            catch (Exception e)
            {
                return Redirect("/Home/contact");
            }

            if (show == null)
                return Redirect("/Home");

            SeatService seatService = new(show, _context);
            var selectedSeats = seatService.OccupyNextSeat(1);

            return RedirectToAction("Index", "Order",
                new { reservedSeats = SeatPositionHelper.SerializeSeatToString(selectedSeats), Id = show.Id });
        }

        public IActionResult SaveCustom(string seatPosition, int id)
        {
            Show? show;
            try
            {
                show = GetShow(id);
            }
            catch (Exception e)
            {
                return Redirect("/Home");
            }

            if (show == null)
                return Redirect("/Home");

            SeatService seatService = new(show, _context);
            var positions = SeatPositionHelper.DeserializePositionToVector2List(seatPosition);

            positions.ForEach(p => seatService.OccupySeat(p));

            return RedirectToAction("Index", "Order",
                new { reservedSeats = SeatPositionHelper.SerializePositionToString(positions), Id = show.Id });
        }

        private Show? GetShow(int id)
        {
            try
            {
                return _context.Shows
                    .Include(v => v.Theatre)
                    .Include(v => v.ShowSeats)
                    .First(s => s.Id == id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
