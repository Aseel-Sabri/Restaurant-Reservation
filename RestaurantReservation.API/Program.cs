using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using RestaurantReservation.API;
using RestaurantReservation.API.Filters;
using RestaurantReservation.API.Validators;
using RestaurantReservation.Db.DbContext;
using RestaurantReservation.Db.Repositories;
using RestaurantReservation.Db.Services;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options => options.Filters.Add<GlobalExceptionFilter>());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services
    .AddFluentValidationAutoValidation(configuration =>
        configuration.OverrideDefaultResultFactoryWith<ValidationResultFactory>())
    .AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssemblyContaining<ModifyEmployeeValidator>();


var connectionString = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<RestaurantReservationDbContext>(options =>
{
    options.UseSqlServer(connectionString)
        .UseProjectables();
});

builder.Services
    .AddScoped<ICustomerRepository, CustomerRepository>()
    .AddScoped<IRestaurantRepository, RestaurantRepository>()
    .AddScoped<IEmployeeRepository, EmployeeRepository>()
    // .AddSingleton<ITableRepository, TableRepository>()
    // .AddSingleton<IReservationRepository, ReservationRepository>()
    // .AddSingleton<IOrderRepository, OrderRepository>()
    // .AddSingleton<IMenuItemRepository, MenuItemRepository>();
    ;
builder.Services
    .AddScoped<ICustomerService, CustomerService>()
// .AddSingleton<IRestaurantService, RestaurantService>()
    .AddScoped<IEmployeeService, EmployeeService>()
// .AddSingleton<ITableService, TableService>()
// .AddSingleton<IReservationService, ReservationService>()
// .AddSingleton<IOrderService, OrderService>()
// .AddSingleton<IMenuItemService, MenuItemService>();
    ;


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();