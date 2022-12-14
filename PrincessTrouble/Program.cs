using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PrincessTrouble;
using PrincessTrouble.model;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>

    {
        services.AddHostedService<Princess>();

        services.AddScoped<IContendersGenerator,ContendersGenerator>();

        services.AddScoped<Hall>();

        services.AddScoped<Friend>();
    })
    .Build();
host.Run();