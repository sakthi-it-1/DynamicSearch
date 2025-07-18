using ClientSearch.Data.Context;
using ClientSearch.Data.Repository;
using ClientSearch.Service.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace ClientSearch.Web.Extensions;

public static class ServiceExtension
{
    public static void AddDBContext(this IServiceCollection services, IConfiguration configurationManager)
    {
        services.AddDbContextPool<ClientInMemoryContext>(
            x => x.UseSqlite(configurationManager["ConnectionStrings:SQLiteDefault"],
            sqlOptions => sqlOptions.MigrationsAssembly("ClientSearch.Web")
            ));

        //services.AddDbContextPool<ClientInMemoryContext>(
        //    x => x.UseSqlServer(configurationManager.GetConnectionString("WeatherForecastContext")


    }

    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped(typeof(IClient<>), typeof(ClientRepo<>));
        services.AddScoped<DbContext, ClientInMemoryContext>();
        services.AddScoped<IClientService,ClientService>();

    }

    public static void CreateDBRuntime(this IServiceProvider services)
    {
        using (var scope = services.CreateScope())
        {
            var db = scope.ServiceProvider.GetRequiredService<ClientInMemoryContext>();
            db.Database.Migrate(); // Apply any pending migrations
            db.Database.EnsureCreated();
        }

    }

     
}
