using PrincessProblem;
using PrincessProblem.model;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>

    {
        services.AddHostedService<Princess>();

        services.AddScoped<ContendersGenerator>();

        services.AddScoped<Hall>();

        services.AddScoped<Friend>();
    })
    .Build();
host.Run();