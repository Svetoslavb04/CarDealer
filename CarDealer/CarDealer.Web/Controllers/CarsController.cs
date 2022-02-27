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

        public ActionResult Index()
        {
            return RedirectToAction("All");
        }

        public async Task<ActionResult> All()
        {
            return View(await carService.GetAllCarsPreview());
        }

        public ActionResult Create()
        {
            return View();
        }

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

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ConfirmDeleting(int id)
        {
            await carService.DeleteById(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
