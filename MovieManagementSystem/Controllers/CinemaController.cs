using FluentAssertions.Common;
using Microsoft.AspNetCore.Mvc;
using MovieManagementSystem.Models;
using MovieManagementSystem.Data.Services;


namespace MovieManagementSystem.Controllers
{
    public class CinemaController : Controller
    {

        private readonly ICinemaService _service; //injecting to perform crud

        public CinemaController(ICinemaService service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            var allCinemas = _service.GetAll(); ;//allCinemas
            return View(allCinemas);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind("Name, Logo,Description")] Cinema cinema)
        {
            // if(!ModelState.IsValid)
            //  {
            //  return View(actor);
            // }



            _service.Add(cinema);
            return RedirectToAction(nameof(Index));
        }


        //UPDATE

        public IActionResult Edit(int id)
        {
            var cinemaDetails = _service.GetById(id);
            if (cinemaDetails == null) { return View("NotFound"); }
            return View(cinemaDetails);
        }

        [HttpPost]
        public IActionResult Edit(int id, [Bind("Id,Name, Logo,Description")] Cinema cinema)
        {
            _service.Update(id, cinema);
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Delete(int id)
        {
            var cinemaDetails = _service.GetById(id);
            return View(cinemaDetails);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var cinemaDetails = _service.GetById(id);
            _service.Delete(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
