using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
            // Fetch categories from the database and order them by name
            ViewBag.Categories = new SelectList(_context.Categories.OrderBy(c => c.CategoryName), "CategoryId", "CategoryName");

            return View();
        }


        [HttpPost]
        public IActionResult Apply(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Add(movie);
                _context.SaveChanges();
                return RedirectToAction("MovieList");
            }

            // Reload categories in case of a validation error
            ViewBag.Categories = new SelectList(_context.Categories.OrderBy(c => c.CategoryName), "CategoryId", "CategoryName");
            return View(movie);
        }


        public IActionResult MovieList()
        {
            var movies = _context.Movies.Include(m => m.Category).ToList(); 
            return View(movies);
        }


        [HttpPost]
        public IActionResult DeleteMovie(int id)
        {
            var movie = _context.Movies.Find(id);
            if (movie != null)
            {
                _context.Movies.Remove(movie);
                _context.SaveChanges();
            }

            return RedirectToAction("MovieList");
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Include the Category entity when fetching the Movie
            var movie = _context.Movies
                        .Include(m => m.Category) // Eager load the Category entity
                        .FirstOrDefault(m => m.Id == id);

            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movies.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            // Fetch categories and assign to ViewBag
            ViewBag.Categories = new SelectList(_context.Categories, "CategoryId", "CategoryName", movie.CategoryId);

            return View(movie);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CategoryId,Title,Year,Director,Rating,Edited,CopiedToPlex,LentTo,Notes")] Movie movie)
        {
            if (id != movie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    if (!MovieExists(movie.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        // Log the exception (ex) or handle it as necessary
                        throw;
                    }
                }
                return RedirectToAction(nameof(MovieList)); // Redirect to the movie list view after successful update
            }
            // If we got this far, something failed; redisplay the form
            ViewBag.Categories = new SelectList(_context.Categories, "CategoryId", "Category", movie.CategoryId); // Repopulate categories for dropdown
            return View(movie);
        }

        private bool MovieExists(int id)
        {
            return _context.Movies.Any(e => e.Id == id);
        }


        public IActionResult Create()
        {
            // Populate categories for dropdown list
            ViewBag.Categories = new SelectList(_context.Categories, "CategoryId", "Category");
            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
