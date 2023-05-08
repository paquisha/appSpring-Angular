using Autofac;
using Autofac.Extensions.DependencyInjection;
using ScoreCard.Infrastructure;
using ScoreCard.Worker;
using Microsoft.EntityFrameworkCore;
using ScoreCard.Worker.Configurations.Autoconfig;
using Serilog;

IConfiguration configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true)
    .Build();

IHost host = Host.CreateDefaultBuilder(args)
    .UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(builder =>
    {
        builder.RegisterModule(new MediatorModule());
        builder.RegisterModule(new RepositoryModule());
        
    })
    .UseSerilog()
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
        services.AddDbContext<ScoreCardDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("BitReportingTool")), ServiceLifetime.Transient);
    })
    .Build();

host.Run();