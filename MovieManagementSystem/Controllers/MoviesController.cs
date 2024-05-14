//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using MovieManagementSystem.Models;

//namespace MovieManagementSystem.Controllers
//{
//    public class MoviesController : Controller
//    {
//        private readonly AppDbContext _context; //injecting to perform crud

//        public MoviesController()
//        {
//            _context = new AppDbContext();
//        }
//        public IActionResult Index()
//        {
//            var allMovies = _context.Movies.ToList();
//            return View(allMovies);
//        }
//    }
//}


using Microsoft.AspNetCore.Mvc;
using MovieManagementSystem.Data.Services;
using MovieManagementSystem.Models;
using System.Linq;

namespace MovieManagementSystem.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieService _service;
        private readonly ICinemaService _cinemaService;

        public MoviesController(IMovieService service, ICinemaService cinemaService)
        {
            _service = service;
            _cinemaService = cinemaService;

        }

        public IActionResult Index()
        {
            var allMovies = _service.GetAll();
            return View(allMovies);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind("Name, Description, Price, ImageURL, StartDate, EndDate, MovieCattegory, CinemaId, ProducerId")] Movie movie)
        {
            //if (!ModelState.IsValid)
            // {
            var cinemas = _cinemaService.GetAll();
            ViewBag.Cinemas = cinemas;


            _service.Add(movie);
                return RedirectToAction(nameof(Index));
            //}
            //return View(movie);
        }

        public IActionResult Edit(int id)
        {
            var movieDetails = _service.GetById(id);
            if (movieDetails == null)
            {
                return View("NotFound");
            }
            return View(movieDetails);
        }

        [HttpPost]
        public IActionResult Edit(int id, [Bind("Id, Name, Description, Price, ImageURL, StartDate, EndDate, MovieCattegory, CinemaId, ProducerId")] Movie movie)
        {
            if (id != movie.Id)
            {
                return View("NotFound");
            }

           // if (ModelState.IsValid)
           // {
                _service.Update(id, movie);
                return RedirectToAction(nameof(Index));
           // }
           // return View(movie);
        }

        public IActionResult Delete(int id)
        {
            var movieDetails = _service.GetById(id);
            return View(movieDetails);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var movieDetails = _service.GetById(id);
            _service.Delete(id);
            return RedirectToAction(nameof(Index));
        }



    }
}

