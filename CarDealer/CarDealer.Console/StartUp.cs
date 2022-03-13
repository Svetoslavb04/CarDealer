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
    using CarDealer.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    public class StartUp
    {
        public static async Task Main()
        {
            var services = new ServiceCollection()
                .AddDbContext<CarDealerContext>(options =>
                options.UseSqlServer(DatabaseConfiguration.DefaultConnectionString))
                .AddAutoMapper(typeof(CarProfile).Assembly)
                .AddScoped<ICarDealerRepository, CarDealerRepository>()
                .AddScoped<ICarService, CarService>()
                .BuildServiceProvider();

            //data is CarDealerRepository which inherits Repository. Repository is an abstraction of the data source.
            //Use data variable as your database. Check the Repository class to see how to access and modify the data
            var carService = services.GetService<ICarService>();
            var data = services.GetService<ICarDealerRepository>();

            Console.SetWindowSize(80, 40);
            Console.WriteLine(new String('-',80));
            Console.Write(new String(' ', 35)); Console.WriteLine("Car Dealer");
            Console.WriteLine(new String('-', 80));
            Console.Write(new String(' ', 5)); Console.WriteLine("Available commands: ");

            string commands = " 01. Add car\n 02. Remove car by ID\n 03. Get car details by ID\n 04. Get peview of all cars\n 05. Search for car by Make or Model\n 06. Get top 3 most powerful cars\n 07. Edit car\n 08.Exit";

            Console.WriteLine(commands);

            while (true)
            {
                bool stop = false;
                Console.WriteLine(new string('-', 80));
                Console.Write(new string(' ',2)); Console.WriteLine("Type the number of command: ");
                Console.Write(new string(' ',2)); Console.Write("Command:"); 
                var leftPosition = Console.GetCursorPosition().Left; var topPosition = Console.GetCursorPosition().Top;
                
                Console.SetCursorPosition(leftPosition+1, topPosition);

                
                string command = Console.ReadLine();
                if (command.Length > 1 && command[0] == '0')
                {
                    command = command.Substring(1);
                }
                Console.WriteLine();
                switch (command)
                {
                    case "1": {
                        CarInputModel car = new CarInputModel();
                        string make = "";
                        string model = "";
                        string message = $"Couldn`t add car {make} {model}";


                        Console.WriteLine("Write the car`s Make:");
                        make = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(make) || make.Length < 2)
                        {
                            Console.WriteLine( "Invalid make!\n" + message); break;
                        }

                        Console.WriteLine("Write the car`s Model:");
                        model = Console.ReadLine();

                        Console.WriteLine("Write the car`s Year:");
                        int year = int.Parse(Console.ReadLine());
                        if (year == null || year < 1960 || year > DateTime.Today.Year)
                        {
                            Console.WriteLine("Invalid year!\n" + message); break;
                        }

                        Console.WriteLine("Write the car`s Color:");
                        string color = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(color) || color.Length < 2)
                        {
                            Console.WriteLine("Invalid color!\n" + message); break;
                        }

                        Console.WriteLine("Write the car`s Engine Capacity:");
                        double engineCapacity = double.Parse(Console.ReadLine());
                        if (engineCapacity == null || engineCapacity < 0.2 || engineCapacity > 7.0)
                        {
                            Console.WriteLine("Invalid Engine Capacity!\n" + message); break;
                        }

                        Console.WriteLine("Write the car`s Horsepower:");
                        int horsepower = int.Parse(Console.ReadLine());
                        if (horsepower == null || horsepower < 10 || horsepower > 1500)
                        {
                            Console.WriteLine("Invalid Horsepower!\n" + message); break;
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
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message); break;
                        }

                        Console.WriteLine( $"Succefully added {make} {model}");
                    } break;
                    case "2": {
                        Console.WriteLine("Write the ID of the car you want to remove:");
                        int id;
                        try
                        {
                            id = int.Parse(Console.ReadLine());
                            await carService.DeleteById(id);
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Invalid id!");
                        }

                        Console.WriteLine("The car was removed!"); 
                     } break;
                    case "3": {
                        Console.WriteLine("Write the ID of the car:");
                        int id = 0;
                        try
                        {
                            id = int.Parse(Console.ReadLine());
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Invalid id!");
                            break;
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
                    } break;
                    case "4": {
                            var cars = await carService.GetAllCarsPreview();
                            StringBuilder sb = new StringBuilder();
                            foreach (var car in cars)
                            {
                               sb.AppendLine(car.ToString());
                                sb.AppendLine();
                             
                            }
                            Console.WriteLine(sb.ToString().TrimEnd());
                        } break;
                    case "5": {
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

                        } break;
                    case "6": {
                            var top3 = await carService.GetTopThreeMostPowerfulCars();
                            StringBuilder sb = new StringBuilder();
                            foreach (var car in top3)
                            {
                                sb.AppendLine(car.ToString());
                                sb.AppendLine();

                            }
                            Console.WriteLine(sb.ToString().TrimEnd());
                        } break;
                    case "7": 
                        { 
                           
                        } break;
                    case "8": { stop = true;
                            Console.WriteLine("Closing ..."); } break;
                    default:
                        { Console.WriteLine("Invalid command!");} break;
                }

                if (stop)
                {
                    break;
                }
            }
            

        }
    }
}