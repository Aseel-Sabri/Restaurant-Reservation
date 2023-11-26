using System.Reflection;
using System.Text;
using FluentValidation;
using FluentValidation.AspNetCore;
using MicroElements.Swashbuckle.FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RestaurantReservation.API.Authentication;
using RestaurantReservation.API.Filters;
using RestaurantReservation.API.Validators;
using RestaurantReservation.Db.DbContext;
using RestaurantReservation.Db.Repositories;
using RestaurantReservation.Db.Services;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new()
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = builder.Configuration["Authentication:Issuer"],
                ValidAudience = builder.Configuration["Authentication:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.ASCII.GetBytes(builder.Configuration["Authentication:SecretForKey"]))
            };
        }
    );
builder.Services.AddAuthorization();
builder.Services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();

builder.Services.AddControllers(options =>
{
    options.Filters.Add<GlobalExceptionFilter>();
    options.ReturnHttpNotAcceptable = true;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var xmlCommentsFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var filePath = Path.Combine(AppContext.BaseDirectory, xmlCommentsFile);
    options.IncludeXmlComments(filePath);
});

builder.Services
    .AddFluentValidationAutoValidation(configuration =>
        configuration.OverrideDefaultResultFactoryWith<ValidationResultFactory>())
    .AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssemblyContaining<ModifyEmployeeValidator>();
builder.Services.AddFluentValidationRulesToSwagger();


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
    .AddScoped<IMenuItemRepository, MenuItemRepository>()
    .AddScoped<IOrderRepository, OrderRepository>()
    .AddScoped<IReservationRepository, ReservationRepository>()
    .AddScoped<ITableRepository, TableRepository>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services
    .AddScoped<ICustomerService, CustomerService>()
    .AddScoped<IRestaurantService, RestaurantService>()
    .AddScoped<IEmployeeService, EmployeeService>()
    .AddScoped<IMenuItemService, MenuItemService>()
    .AddScoped<IOrderService, OrderService>()
    .AddScoped<IReservationService, ReservationService>()
    .AddScoped<ITableService, TableService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();