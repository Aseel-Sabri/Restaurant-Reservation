﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RestaurantReservation.Db;
using RestaurantReservation.Db.Repositories;
using RestaurantReservation.Db.Services;
using RestaurantReservation.EntityOperations;

namespace RestaurantReservation;

public class AppConfig
{
    private static ServiceProvider _serviceProvider;

    public static void ConfigureServices()
    {
        var connectionString = GetConnectionString();

        _serviceProvider = new ServiceCollection()
            .AddDbContext<RestaurantReservationDbContext>(options =>
                options.UseSqlServer(connectionString))
            .AddSingleton<ICustomerRepository, CustomerRepository>()
            .AddSingleton<ICustomerService, CustomerService>()
            .AddSingleton<CustomerOperations>()
            .BuildServiceProvider();
    }

    public static T GetService<T>()
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
}