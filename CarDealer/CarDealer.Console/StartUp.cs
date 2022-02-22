﻿namespace CarDealer.Console
{
    using CarDealer.Common;
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
                .AddScoped<ICarDealerRepository, CarDealerRepository>()
                .BuildServiceProvider();

            //data is CarDealerRepository which inherits Repository. Repository is an abstraction of the data source.
            //Use data variable as your database. Check the Repository class to see how to access and modify the data
            var data = services.GetService<ICarDealerRepository>();

            Console.WriteLine(data.All<Car>());
        }
    }
}