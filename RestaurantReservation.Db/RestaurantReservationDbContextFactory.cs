using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace RestaurantReservation.Db;

public class RestaurantReservationDbContextFactory : IDesignTimeDbContextFactory<RestaurantReservationDbContext>
{
    public RestaurantReservationDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<RestaurantReservationDbContext>();
        // TODO
        optionsBuilder.UseSqlServer(
            "Server=localhost;Database=RestaurantReservationCore;Integrated Security=True;Encrypt=False"
        );
        return new RestaurantReservationDbContext(optionsBuilder.Options);
    }
}