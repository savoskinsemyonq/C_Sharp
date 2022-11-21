using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PrincessProblem;
using PrincessProblem.model;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>

    {
        services.AddHostedService<Princess>();

        services.AddScoped<ContendersGenerator>();

        services.AddScoped<Hall>();

        services.AddScoped<Friend>();
    })
    .Build();
host.Run();