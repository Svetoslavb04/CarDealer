namespace CarDealer.Console
{
    using CarDealer.Common;
    using CarDealer.Core.Mapping;
    using CarDealer.Core.Models.InputModels;
    using CarDealer.Core.Services;
    using CarDealer.Core.Services.Contracts;
    using CarDealer.Data;
    using CarDealer.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using System;

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
            var carServie = services.GetService<ICarService>();
            var data = services.GetService<ICarDealerRepository>();
        }
    }
}