using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RestaurantReservation.Db.DbContext;
using RestaurantReservation.Db.Repositories;
using RestaurantReservation.Db.Services;
using RestaurantReservation.EntityOperations;

namespace RestaurantReservation;

public class AppConfig
{
    private static ServiceProvider _serviceProvider;

    public static void ConfigureServices()
    {
        var serviceCollection = new ServiceCollection();
        ConfigureDbContext(serviceCollection);
        ConfigureEntitiesRepositories(serviceCollection);
        ConfigureEntitiesServices(serviceCollection);
        ConfigureEntitiesOperations(serviceCollection);

        _serviceProvider = serviceCollection.BuildServiceProvider();
    }

    public static T? GetService<T>()
    {
        return _serviceProvider.GetService<T>();
    }

    private static string? GetConnectionString()
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        var connectionString = configuration.GetConnectionString("Default");
        return connectionString;
    }

    private static void ConfigureDbContext(IServiceCollection serviceCollection)
    {
        var connectionString = GetConnectionString();

        serviceCollection.AddDbContext<RestaurantReservationDbContext>(options =>
            options.UseSqlServer(connectionString));
    }

    private static void ConfigureEntitiesRepositories(IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddSingleton<ICustomerRepository, CustomerRepository>()
            .AddSingleton<IRestaurantRepository, RestaurantRepository>()
            .AddSingleton<IEmployeeRepository, EmployeeRepository>()
            .AddSingleton<ITableRepository, TableRepository>()
            .AddSingleton<IReservationRepository, ReservationRepository>()
            .AddSingleton<IOrderRepository, OrderRepository>()
            .AddSingleton<IMenuItemRepository, MenuItemRepository>();
    }

    private static void ConfigureEntitiesServices(IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddSingleton<ICustomerService, CustomerService>()
            .AddSingleton<IRestaurantService, RestaurantService>()
            .AddSingleton<IEmployeeService, EmployeeService>()
            .AddSingleton<ITableService, TableService>()
            .AddSingleton<IReservationService, ReservationService>()
            .AddSingleton<IOrderService, OrderService>()
            .AddSingleton<IMenuItemService, MenuItemService>();
    }

    private static void ConfigureEntitiesOperations(IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddSingleton<CustomerOperations>()
            .AddSingleton<RestaurantOperations>()
            .AddSingleton<EmployeeOperations>()
            .AddSingleton<TableOperations>()
            .AddSingleton<ReservationOperations>()
            .AddSingleton<OrderOperations>()
            .AddSingleton<MenuItemOperations>();
    }
}