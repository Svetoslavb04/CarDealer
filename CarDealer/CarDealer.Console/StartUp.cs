namespace CarDealer.Console
{
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

            System.Console.WriteLine(data.All<Car>());
        }
    }
}