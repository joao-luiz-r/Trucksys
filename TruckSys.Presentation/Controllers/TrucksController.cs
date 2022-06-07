using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TruckSys.Domain.Interfaces.Services;
using TruckSys.Entities;
using TruckSys.Infra.Data;

namespace TruckSys.Presentation.Controllers
{
    public class TrucksController : Controller
    {
        private readonly ITruckService _truckService;

        public TrucksController(ITruckService truckService)
        {
            _truckService = truckService;
        }

        // GET: Trucks
        public async Task<IActionResult> Index()
        {
            var trucks = _truckService.GetAll();
              return trucks != null ? 
                          View(trucks) :
                          Problem("Entity set 'TruckSysPresentationContext.Truck'  is null.");
        }

        // GET: Trucks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) 
              return NotFound();

            var truck = _truckService.GetById((int)id);

            if (truck == null)
              return NotFound();

            return View(truck);
        }

        // GET: Trucks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Trucks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Modelo,AnoFabricacao,AnoModelo")] Truck truck)
        {
            if (ModelState.IsValid)
            {
                _truckService.Add(truck);
                return RedirectToAction(nameof(Index));
            }
            return View(truck);
        }

        // GET: Trucks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var truck = _truckService.GetById((int)id);

            if (truck == null)
                return NotFound();

            return View(truck);
        }

        // POST: Trucks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Modelo,AnoFabricacao,AnoModelo")] Truck truck)
        {
            if (id != truck.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _truckService.Update(truck);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TruckExists(truck.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(truck);
        }

        // GET: Trucks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var truck = _truckService.GetById((int)id);

            if (truck == null)
                return NotFound();

            return View(truck);
        }

        // POST: Trucks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var truck = _truckService.GetById((int)id);

            if (truck != null)
                _truckService.Delete(truck);

            return RedirectToAction(nameof(Index));
        }

        private bool TruckExists(int id) => _truckService.GetById(id) != null;

    }
}
