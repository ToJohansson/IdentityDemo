using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Tournament.Application.Interfaces;
using Tournament.Application.Services;
using Tournament.Infrastructure.Data;
using Tournament.Infrastructure.Repositories;
using Tournamet.Api.Extensions;

namespace Tournamet.Api
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<TournamentContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("TournametContext") ?? throw new InvalidOperationException("Connection string 'TournametContext' not found.")));

            // Add services to the container.

            builder.Services.AddControllers(opt => opt.ReturnHttpNotAcceptable = true)
               .AddNewtonsoftJson(options =>
               {
                   options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore; // Delete this later
               })
                .AddXmlDataContractSerializerFormatters();
            builder.Services.AddAutoMapper(typeof(TournamentMappings));

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<ITournamentRepository, TournamentRepository>();
            builder.Services.AddScoped<IGameRepository, GameRepository>();
            builder.Services.AddScoped<ITournamentService, TournamentService>();
            builder.Services.AddScoped<IGameService, GameService>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                await app.SeedDataAsync();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
