using System.Reflection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ScoreCard.Api.Configurations.AutofacConfig;
using ScoreCard.Api;
using ScoreCard.Infrastructure;
using ScoreCard.Infrastructure.JsonResolver;
using ScoreCard.Infrastructure.Middlewares;
using Serilog;
using Serilog.Exceptions;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

// Add services to the container.
//Instance configurations
var appSettings = new AppSettings();
configuration.Bind(appSettings);

builder.Services.AddHttpContextAccessor();
builder.Services.AddControllers()
    .AddNewtonsoftJson(opt =>
        opt.SerializerSettings.ContractResolver = new PrivateSetterContractResolver());

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ScoreCardDbContext>(options =>
    options.UseSqlServer(appSettings.ConnectionStrings?.BitReportingTool!), ServiceLifetime.Transient);

//register services of configuration
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
    containerBuilder.RegisterModule(new RepositoryModule()));
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
    containerBuilder.RegisterModule(new MediatorModule()));

builder.Services.AddMemoryCache();
//cors
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        builder =>
        {
            builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
        });
});
//Add serilog
var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(configuration)
    .MinimumLevel.Verbose()
    .Enrich.WithProperty("ScoreCardDbContext", "ScoreCard.Api")
    .Enrich.FromLogContext()
    .Enrich.WithExceptionDetails()
    .WriteTo.Console()
    .CreateLogger();
builder.Host.UseSerilog(logger);

// Register the Swagger generator
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "ScoreCard Api ",
        Description = "Api rest para ScoreCard ",
        Contact = new OpenApiContact
        {
            Name = "Lidia Enriquez || Brandon Almeida || Andres Grijalva",
            Email = "lidia.enriquez@grupobusiness.it; brandon.almeida@grupobusiness.it; andres.grijalva@grupobusiness.it"
        }
    });

    // Set the comments path for the Swagger JSON and UI.
   var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
   var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
   c.IncludeXmlComments(xmlPath);
});

var app = builder.Build();
app.UseSerilogRequestLogging();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "ScoreCard Api"); });

app.UseCors(MyAllowSpecificOrigins);
app.UseHttpsRedirection();
app.UseRouting();
app.UseMiddleware<RequestResponseLoggingMiddleware>();
app.UseMiddleware<ExceptionMiddleware>();
app.UseAuthorization();

app.MapControllers();

app.Run();




