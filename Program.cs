using EmissionDataRecordService.Data;
using EmissionDataRecordService.Middleware;
using EmissionDataRecordService.Repository;
using EmissionDataRecordService.Service;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Configure Serilog for logging
builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));

// Add services to the container.  
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle  
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(); // Register Swagger services for API documentation

builder.Services.AddDbContext<EmissionDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))); // Register the DbContext with SQL Server provider

builder.Services.AddScoped<IEmissionDataService, EmissionDataService>(); // Register the service interface and its implementation

builder.Services.AddScoped<IEmissionRepositoryInterface,EmissionDataRepository>(); // Register the repository interface and its implementation

var app = builder.Build();

// Configure the HTTP request pipeline.  
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseSerilogRequestLogging(); // Enable Serilog request logging

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();