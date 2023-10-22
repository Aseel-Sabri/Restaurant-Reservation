using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using RestaurantReservation.Db.DbContext;

namespace RestaurantReservation;

public class RestaurantReservationDbContextFactory : IDesignTimeDbContextFactory<RestaurantReservationDbContext>
{
    public RestaurantReservationDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<RestaurantReservationDbContext>();
        optionsBuilder.UseSqlServer(AppConfig.GetConnectionString());
        return new RestaurantReservationDbContext(optionsBuilder.Options);
    }
}