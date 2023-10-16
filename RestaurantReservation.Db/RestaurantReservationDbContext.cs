using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db;

public class RestaurantReservationDbContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<MenuItem> MenuItems { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<Restaurant> Restaurants { get; set; }
    public DbSet<Table> Tables { get; set; }

    public RestaurantReservationDbContext(DbContextOptions<RestaurantReservationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MenuItem>()
            .HasKey(item => item.ItemId);

        modelBuilder.Entity<MenuItem>()
            .Property(menuItem => menuItem.Price)
            .HasColumnType("decimal(18, 2)");


        foreach (var foreignKey in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
        {
            foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
        }

        modelBuilder.Entity<Order>(orderBuilder =>
            {
                orderBuilder.Property(order => order.TotalAmount)
                    .HasColumnType("decimal(18, 2)");
                orderBuilder.HasMany(order => order.OrderItems)
                    .WithOne(orderItem => orderItem.Order)
                    .HasForeignKey(orderItem => orderItem.OrderId)
                    .OnDelete(DeleteBehavior.Cascade);

                orderBuilder.HasOne(order => order.Reservation)
                    .WithMany()
                    .HasForeignKey(order => order.ReservationId)
                    .OnDelete(DeleteBehavior.Cascade);
            }
        );

        DataSeeder.SeedData(modelBuilder);
    }
}