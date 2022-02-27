using AutoMapper;
using CarDealer.Core.Models.InputModels;
using CarDealer.Core.Models.OutputModels;
using CarDealer.Core.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace CarDealer.Web.Controllers
{
    public class CarsController : Controller
    {
        private ICarService carService;
        public CarsController(ICarService carService)
        {
            this.carService = carService;
        }

        // GET: CarsController
        public ActionResult Index()
        {
            return RedirectToAction("All");
        }

        //GET: CarsController/All
        public async Task<ActionResult> All()
        {
            return View(await carService.GetAllCarsPreview());
        }

        // GET: CarsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CarsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CarInputModel carInputModel)
        {
            if (ModelState.IsValid)
            {
                await carService.AddCar(carInputModel);

                return RedirectToAction(nameof(Index));
            }

            return View(carInputModel);
        }
        
        // GET: CarsController/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await carService.GetCarDetailsById((int)id);

            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // GET: CarsController/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await carService.GetCarDetailsById((int)id);

            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // POST: CarsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, CarDetailsModel car)
        {
            if (id != car.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if ((await carService.EditCar(car)) == false)
                {
                    return NotFound();
                }

                return RedirectToAction(nameof(Index));
            }

            return View(car);
        }

        // GET: CarsController/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await carService.GetCarDetailsById((int)id);

            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // POST: CarsController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ConfirmDeleting(int id)
        {
            await carService.DeleteById(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
