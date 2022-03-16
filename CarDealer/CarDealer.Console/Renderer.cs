namespace CarDealer.Console
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CarDealer.Common;
    using CarDealer.Core.Mapping;
    using CarDealer.Core.Models.InputModels;
    using CarDealer.Core.Models.OutputModels;
    using CarDealer.Core.Services;
    using CarDealer.Core.Services.Contracts;
    using CarDealer.Data;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    public class Renderer : IRenderer
    {
        private ICarService carService;

        public Renderer(ICarService _carService)
        {
            carService = _carService;
        }

        public async Task RenderMainMenu()
        {
            Console.WriteLine(new String('-', 80));
            Console.Write(new String(' ', 35)); Console.WriteLine("Car Dealer");
            Console.WriteLine(new String('-', 80));
            Console.Write(new String(' ', 5)); Console.WriteLine("Available commands: ");

            string commands = " 01. Add car\n 02. Remove car by ID\n 03. Get car details by ID\n 04. Get preview of all cars\n 05. Search for car by Make or Model\n 06. Get top 3 most powerful cars\n 07. Edit car\n 08.Exit";

            Console.WriteLine(commands);
            Console.WriteLine(new string('-', 80));
        }

        public async Task RenderAddCar()
        {
            Console.Clear();
            RenderMainMenu();

            CarInputModel car = new CarInputModel();

            string make = "";
            string model = "";
            string message = $"Couldn`t add car {make} {model}";

            Console.WriteLine("Write the car`s Make:");

            make = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(make) || make.Length < 2)
            {
                Console.WriteLine("Invalid make!\n" + message); return;
            }

            Console.WriteLine("Write the car`s Model:");
            model = Console.ReadLine();

            Console.WriteLine("Write the car`s Year:");

            int year = int.Parse(Console.ReadLine());

            if (year == null || year < 1960 || year > DateTime.Today.Year)
            {
                Console.WriteLine("Invalid year!\n" + message); return;
            }

            Console.WriteLine("Write the car`s Color:");

            string color = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(color) || color.Length < 2)
            {
                Console.WriteLine("Invalid color!\n" + message); return;
            }

            Console.WriteLine("Write the car`s Engine Capacity:");

            double engineCapacity = double.Parse(Console.ReadLine());

            if (engineCapacity == null || engineCapacity < 0.2 || engineCapacity > 7.0)
            {
                Console.WriteLine("Invalid Engine Capacity!\n" + message); return;
            }

            Console.WriteLine("Write the car`s Horsepower:");

            int horsepower = int.Parse(Console.ReadLine());

            if (horsepower == null || horsepower < 10 || horsepower > 1500)
            {
                Console.WriteLine("Invalid Horsepower!\n" + message); return;
            }

            car.Make = make;
            car.Model = model;
            car.Year = year;
            car.Color = color;
            car.EngineCapacity = engineCapacity;
            car.Horsepower = horsepower;

            try
            {
                await carService.AddCar(car);
                Console.WriteLine($"Succefully added {make} {model}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); return;
            }
        }

        public async Task RenderRemoveCarById()
        {
            Console.Clear();
            RenderMainMenu();

            Console.WriteLine("Write the ID of the car you want to remove:");
            int id;
            try
            {
                id = int.Parse(Console.ReadLine());
                await carService.DeleteById(id);
                Console.WriteLine("The car was removed!");
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid id!");
            }
        }

        public async Task RenderCarDetailsById()
        {
            Console.Clear();
            RenderMainMenu();

            Console.WriteLine("Write the ID of the car:");
            int id = 0;
            try
            {
                id = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid id!");
                return;
            }

            var car = await carService.GetCarDetailsById(id);
            if (car != null)
            {
                Console.WriteLine(car.ToString());
            }
            else
            {
                Console.WriteLine("Invalid id!");
            }
        }

        public async Task RenderPreviewAllCars()
        {
            Console.Clear();
            RenderMainMenu();

            var cars = await carService.GetAllCarsPreview();
            StringBuilder sb = new StringBuilder();
            foreach (var car in cars)
            {
                sb.AppendLine(car.ToString());
                sb.AppendLine();

            }
            Console.WriteLine(sb.ToString().TrimEnd());
        }

        public async Task RenderSearchCarByMakeAndModel()
        {
            Console.Clear();
            RenderMainMenu();

            Console.WriteLine("Search by:");
            string search = Console.ReadLine();

            var cars = await carService.GetAllCarsPreviewSearchedByMakeOrModel(search);
            StringBuilder sb = new StringBuilder();
            foreach (var car in cars)
            {
                sb.AppendLine(car.ToString());
                sb.AppendLine();

            }
            Console.WriteLine(sb.ToString().TrimEnd());
        }

        public async Task RenderTopThreePowerful()
        {
            Console.Clear();
            RenderMainMenu();

            var top3 = await carService.GetTopThreeMostPowerfulCars();
            StringBuilder sb = new StringBuilder();
            foreach (var car in top3)
            {
                sb.AppendLine(car.ToString());
                sb.AppendLine();

            }
            Console.WriteLine(sb.ToString().TrimEnd());
        }

        public async Task RenderEditCar()
        {
            Console.Clear();
            RenderMainMenu();

            Console.WriteLine("Write the ID of the car:");
            int id = 0;
            try
            {
                id = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid id!");
                return;
            }

            var car = await carService.GetCarDetailsById(id);
            if (car != null)
            {
                Console.WriteLine(car.ToString());
            }
            else
            {
                Console.WriteLine("Invalid id!");
                return;
            }

            CarDetailsModel carModel = new CarDetailsModel()
            {
                Id = id
            };

            Console.WriteLine("Write the car`s Make:");

            car.Make = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(car.Make) || car.Make.Length < 2)
            {
                Console.WriteLine("Invalid make!\n"); return;
            }

            Console.WriteLine("Write the car`s Model:");
            car.Model = Console.ReadLine();

            Console.WriteLine("Write the car`s Year:");

            car.Year = int.Parse(Console.ReadLine());

            if (car.Year == null || car.Year < 1960 || car.Year > DateTime.Today.Year)
            {
                Console.WriteLine("Invalid year!\n"); return;
            }

            Console.WriteLine("Write the car`s Color:");

            car.Color = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(car.Color) || car.Color.Length < 2)
            {
                Console.WriteLine("Invalid color!\n"); return;
            }

            Console.WriteLine("Write the car`s Engine Capacity:");

            car.EngineCapacity = double.Parse(Console.ReadLine());

            if (car.EngineCapacity == null || car.EngineCapacity < 0.2 || car.EngineCapacity > 7.0)
            {
                Console.WriteLine("Invalid Engine Capacity!\n"); return;
            }

            Console.WriteLine("Write the car`s Horsepower:");

            car.Horsepower = int.Parse(Console.ReadLine());

            if (car.Horsepower == null || car.Horsepower < 10 || car.Horsepower > 1500)
            {
                Console.WriteLine("Invalid Horsepower!\n"); return;
            }

            try
            {
                await carService.EditCar(car);
                Console.WriteLine($"Succefully edited {car.Make} {car.Model}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); return;
            }
        }

        public async Task Exit()
        {
            Console.WriteLine("Closing ...");
            Thread.Sleep(2000);
            Environment.Exit(0);
        }
    }
}
