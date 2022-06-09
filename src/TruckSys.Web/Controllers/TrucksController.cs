using Microsoft.AspNetCore.Mvc;
using TruckSys.Domain.Interfaces.Services;
using TruckSys.Entities;

namespace TruckSys.Web.Controllers
{
    public class TrucksController : Controller
    {
        private readonly ITruckService _service;

        public TrucksController(ITruckService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return _service.GetAll() != null ?
                        View(_service.GetAll()) :
                        Problem("Nenhum caminhão cadastrado.");
        }

        public IActionResult Details(int? id)
        {
            if (id == null || _service.GetAll() == null)
            {
                return NotFound();
            }

            var truck = _service.GetAll()
                .FirstOrDefault(m => m.Id == id);
            if (truck == null)
            {
                return NotFound();
            }

            return View(truck);
        }

        public IActionResult Create()
        {
            var truck = new Truck();
            return View(truck);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Modelo,AnoFabricacao,AnoModelo")] Truck truck)
        {
            truck.errormessages = new List<string>();
            truck = _service.Add(truck);
            if (!truck.errormessages.Any())
                return RedirectToAction(nameof(Index));
            return View(truck);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || _service.GetById((int)id) == null)
            {
                return NotFound();
            }

            var truck = _service.GetById((int)id);
            if (truck == null)
            {
                return NotFound();
            }
            return View(truck);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Modelo,AnoFabricacao,AnoModelo")] Truck truck)
        {
            _service.Update(truck);
            if (!truck.errormessages.Any())
                return RedirectToAction(nameof(Index));
            return View(truck);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || _service.GetById((int)id) == null)
            {
                return NotFound();
            }

            var truck = _service.GetById((int)id);
            if (truck == null)
            {
                return NotFound();
            }

            return View(truck);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _service.Delete((int)id);
            return RedirectToAction(nameof(Index));
        }

        private bool TruckExists(int id)
        {
            return _service.GetById((int)id) != null;
        }
    }
}
