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
                .AddTransient<ICarDealerRepository, CarDealerRepository>()
                .AddTransient<ICarService, CarService>()
                .AddTransient<IRenderer, Renderer>()
                .BuildServiceProvider();

            //data is CarDealerRepository which inherits Repository. Repository is an abstraction of the data source.
            //Use data variable as your database. Check the Repository class to see how to access and modify the data
            var carService = services.GetService<ICarService>();
            var data = services.GetService<ICarDealerRepository>();
            var render = services.GetService<IRenderer>();

            Console.SetWindowSize(80, 40);

            render.RenderMainMenu();

            while (true)
            {
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
                        await render.RenderAddCar();
                    } break;
                    case "2": {
                        await render.RenderRemoveCarById();
                     } break;
                    case "3": {
                        await render.RenderCarDetailsById();
                    } break;
                    case "4": {
                        await render.RenderPreviewAllCars();
                        } break;
                    case "5": {
                        await render.RenderSearchCarByMakeAndModel();
                        } break;
                    case "6": {
                        await render.RenderTopThreePowerful();
                        } break;
                    case "7": {
                        await render.RenderEditCar();
                        } break;
                    case "8": {
                            await render.Exit();
                        } break;
                    default:
                        { Console.WriteLine("Invalid command!");} break;
                }
            }
        }
    }
}