
using Microsoft.EntityFrameworkCore;
using ProductInventoryManagementSystem.Services;
using ProductInventoryManagementSystem.Services.Interfaces;
using ProductInventoryManagementSystem.Services.ProductServices;

namespace ProductInventoryManagementSystem.Operations
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            // Register Services
            builder.Services.AddScoped<IProductServices, ProductRepository>();

            // Configure Entity Framework Core to use SQLite as the database provider and set up the connection string from the configuration
            builder.Services.AddDbContext<ProductDbContext>(options =>
                options.UseSqlite(builder.Configuration.GetConnectionString("ProductDbConnection")));

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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
        }
    }
}
