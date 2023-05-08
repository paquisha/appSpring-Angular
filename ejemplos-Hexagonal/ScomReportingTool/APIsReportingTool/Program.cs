using ADReporting;
using ADScomDataWarehouse;
using ADScomDataWarehouse.Entities;
using ADScomLive.Entities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ReportingToolContext>(options => 
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ReportingTool"));
});
builder.Services.AddDbContext<OperationsManagerDwContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("OperationManagerDW"));
});
builder.Services.AddDbContext<OperationsManagerContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("OperationManagerLive"));
});
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ReportingToolContext>();
    context.Database.Migrate();
}


    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
