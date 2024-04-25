using BookStore.Application;
using BookStore.DataAccess;
using BookStore.DataAccess.Repositories;
using BookStore.UseCases.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace BookStore.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<BookStoreDbContext>(options =>
            {
                options.UseNpgsql(builder.Configuration.GetConnectionString("BookStoreDbContext"));
            });
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<IBooksService, BooksService>();
            builder.Services.AddScoped<IBooksRepository, BookRepository>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
