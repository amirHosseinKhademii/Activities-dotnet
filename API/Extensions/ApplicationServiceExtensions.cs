using Application.Activities;
using Application.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Presistence;

namespace API.Extensions;

public static class ApplicationServiceExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddDbContext<DataContext>(options =>
        {
            options.UseSqlite(config.GetConnectionString("DefaultConnection"));
        });
        services.AddMediatR(typeof(List.Handler).Assembly);
        services.AddAutoMapper(typeof(MappingProfiles).Assembly);
        var context = services.BuildServiceProvider().GetService<DataContext>();
        context.Database.Migrate();
        Seed.SeedData(context).Wait();

        return services;
    }

}