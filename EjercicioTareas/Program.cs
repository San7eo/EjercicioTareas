using EjercicioTareas.Repository;
using EjercicioTareas.Repository.Interfaces;
using EjercicioTareas.Service;
using EjercicioTareas.Service.InterfazService;
using Microsoft.EntityFrameworkCore;

namespace EjercicioTareas
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<ToDOContext>(
                options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped<ITareasService, TareasService>();
            builder.Services.AddScoped<ITareaRepository, TareaRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.UseSwagger();
            app.UseSwaggerUI();

            app.MapControllers();

            app.Run();

        }
    }
}
