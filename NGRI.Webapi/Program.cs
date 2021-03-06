using Serilog;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NGRI.Webapi.Data;
using NGRI.Library.Interfaces;
using NGRI.Library.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<NGRIWebapiContext>();

// Add services to the container.
builder.Services.AddScoped<IEstateService, EstateService>();
builder.Services.AddScoped<IConditionReportService, ConditionReportService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add Serilog with output to file
builder.Host.UseSerilog((ctx, lc) => lc.WriteTo.File("Logs/log.txt", rollingInterval: RollingInterval.Day, outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}"));

var app = builder.Build();

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
