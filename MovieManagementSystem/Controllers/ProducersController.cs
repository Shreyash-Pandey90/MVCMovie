using Microsoft.AspNetCore.Mvc;
using MovieManagementSystem.Data.Services;
using MovieManagementSystem.Models;

namespace MovieManagementSystem.Controllers
{
    public class ProducersController : Controller
    {
        private readonly IProducerService _service;

        public ProducersController(IProducerService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            var allProducers = _service.GetAll();
            return View(allProducers);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind("FulllName, ProfilePictureURL, Bio")] Producer producer)
        {
            //if (!ModelState.IsValid)
            //{
              //  return View(producer);
            //}

            _service.Add(producer);
            return RedirectToAction(nameof(Index));
        }

        //UPDATE

        public IActionResult Edit(int id)
        {
            var producerDetails = _service.GetById(id);
            if (producerDetails == null)
            {
                return View("NotFound");
            }
            return View(producerDetails);
        }

        [HttpPost]
        public IActionResult Edit(int id, [Bind("Id, FulllName, ProfilePictureURL, Bio")] Producer producer)
        {
            _service.Update(id, producer);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var producerDetails = _service.GetById(id);
            return View(producerDetails);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var producerDetails = _service.GetById(id);
            _service.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
