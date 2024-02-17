using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mission06_Hicks.Models;
using Mission06_LastName.Data; // Ensure this namespace is corrected to match your project's structure
using Mission06_LastName.Models;
using System.Diagnostics;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Mission06_Hicks.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<HomeController> _logger;

        // Consolidated constructor
        public HomeController(ApplicationDbContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult NMovie()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Apply(Movie movie)
        {

            movie.LentTo = movie.LentTo ?? string.Empty;
            movie.Notes = movie.Notes ?? string.Empty;
            movie.SubCategory = movie.SubCategory ?? string.Empty;

            if (ModelState.IsValid)
            {
                _context.Movies.Add(movie);
                _context.SaveChanges();

                return View("Index");
            }
            else
            {
                return View("About");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
