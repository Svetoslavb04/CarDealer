using CarDealer.Core.Services.Contracts;
using CarDealer.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CarDealer.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICarService carService;

        public HomeController(ILogger<HomeController> logger, ICarService carService)
        {
            _logger = logger;
            this.carService = carService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await carService.GetTopThreeMostPowerfulCars());
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
    }
}