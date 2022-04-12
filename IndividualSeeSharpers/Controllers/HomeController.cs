using IndividualSeeSharpers.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Dynamic;
using IndividualSeeSharpers.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace IndividualSeeSharpers.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SeeSharpersContext _context;

        public HomeController(ILogger<HomeController> logger, SeeSharpersContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            
            var movie = new List<Movie>(await _context.Movie.ToListAsync());
            var show = new List<Show>(await _context.Shows.Where(s => s.StartDateTime > DateTime.Now).ToListAsync());
            

            var movieShowViewModel = new HomeIndexViewModel()
            {
                Movies = movie,
                Shows = show
            };

            return View(movieShowViewModel);
        }

        [HttpPost]
        public IActionResult CultureManagement(string culture, string returnUrl)
        {
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.Now.AddDays(30) });

            return LocalRedirect(returnUrl);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Authorize("EmployeeAccess")]
        public IActionResult Dashboard()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }


        public async Task<IActionResult> ShowSelection(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            
            var movie = await _context.Movie
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            /*var movies = movie;*/
            var show = new List<Show>(await _context.Shows.Where(s => s.StartDateTime > DateTime.Now).ToListAsync());


            var movieShowViewModel = new ShowSelectionViewModel()
            {
                Movie = movie,
                Shows = show
            };

            return View(movieShowViewModel);
        }

    }
}