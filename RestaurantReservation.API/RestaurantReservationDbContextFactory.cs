using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using RestaurantReservation.Db.DbContext;

namespace RestaurantReservation.API;

public class RestaurantReservationDbContextFactory : IDesignTimeDbContextFactory<RestaurantReservationDbContext>
{
    public RestaurantReservationDbContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json")
            .Build();

        var optionsBuilder = new DbContextOptionsBuilder<RestaurantReservationDbContext>();
        optionsBuilder.UseSqlServer(configuration.GetConnectionString("Default"));
        return new RestaurantReservationDbContext(optionsBuilder.Options);
    }
}