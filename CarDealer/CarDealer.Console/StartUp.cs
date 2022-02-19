using CarDealer.Common;
using CarDealer.Data;
using CarDealer.Data.Common;
using CarDealer.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CarDealer.Console
{
    public class StartUp
    {
        public static async Task Main()
        {
            var services = new ServiceCollection()
                .AddDbContext<CarDealerContext>(options =>
                options.UseSqlServer(DatabaseConfiguration.DeffaultConnectionString))
                .AddScoped<IRepository, CarDealerRepository>()
                .BuildServiceProvider();

            var database = services.GetService<IRepository>();

            await database.DeleteAsync<Car>(1);
            database.SaveChanges();
            foreach (var car in database.All<Car>())
            {
                System.Console.WriteLine(car.Make);
            }
        }
    }
}